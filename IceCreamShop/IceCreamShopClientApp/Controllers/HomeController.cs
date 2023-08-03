using IceCreamShopClientApp.Models;
using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace IceCreamShopClientApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			if (APIClient.Client == null)
			{
				return Redirect("~/Home/Enter");
			}
			return View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={APIClient.Client.Id}"));
		}

		[HttpGet]
		public IActionResult Privacy()
		{
			if (APIClient.Client == null)
			{
				return Redirect("~/Home/Enter");
			}
			return View(APIClient.Client);
		}

		[HttpPost]
		public void Privacy(string login, string password, string fio)
		{
			if (APIClient.Client == null)
			{
				throw new Exception("Вы как суда попали? Суда вход только авторизованным");
			}
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
			{
				throw new Exception("Введите логин, пароль и ФИО");
			}
			APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
			{
				Id = APIClient.Client.Id,
				ClientFIO = fio,
				Email = login,
				Password = password
			});

			APIClient.Client.ClientFIO = fio;
			APIClient.Client.Email = login;
			APIClient.Client.Password = password;
			Response.Redirect("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public IActionResult Enter()
		{
			return View();
		}

		[HttpPost]
		public void Enter(string login, string password)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
			{
				throw new Exception("Введите логин и пароль");
			}
			APIClient.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
			if (APIClient.Client == null)
			{
				throw new Exception("Неверный логин/пароль");
            }

			APIClient.MaxPages = (int)Math.Ceiling(APIClient.GetRequest<List<MessageInfoViewModel>>($"api/client/getmessages?clientId={APIClient.Client.Id}").Count / 2.0);
            Response.Redirect("Index");
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public void Register(string login, string password, string fio)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
			{
				throw new Exception("Введите логин, пароль и ФИО");
			}
			APIClient.PostRequest("api/client/register", new ClientBindingModel
			{
				ClientFIO = fio,
				Email = login,
				Password = password
			});
			Response.Redirect("Enter");
			return;
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.IceCreams = APIClient.GetRequest<List<IceCreamViewModel>>("api/main/geticecreamlist");
			return View();
		}

		[HttpPost]
		public void Create(int iceCream, int count)
		{
			if (APIClient.Client == null)
			{
				throw new Exception("Вы как суда попали? Суда вход только авторизованным");
			}
			if (count <= 0)
			{
				throw new Exception("Количество и сумма должны быть больше 0");
			}
			APIClient.PostRequest("api/main/createorder", new OrderBindingModel
			{
				ClientId = APIClient.Client.Id,
				IceCreamId = iceCream,
				Count = count,
				Sum = Calc(count, iceCream)
			});
			Response.Redirect("Index");
		}

		[HttpPost]
		public double Calc(int count, int iceCream)
		{
			var iceCr = APIClient.GetRequest<IceCreamViewModel>($"api/main/geticecream?icecreamId={iceCream}");
			return count * (iceCr?.Price ?? 1);
		}

		[HttpGet]
		public IActionResult Mails(int page = 1)
		{
			if (APIClient.Client == null)
			{
				return Redirect("~/Home/Enter");
			}
			bool next, prev;
            ValidateButtons(page, out next, out prev);
			ViewBag.Next = next;
			ViewBag.Prev = prev;
			ViewBag.Page = page;
            return View(APIClient.GetRequest<List<MessageInfoViewModel>>($"api/client/getmessages?clientId={APIClient.Client.Id}&currentPage={page}"));
		}
        private void ValidateButtons(int currentPage, out bool nextButton, out bool prevButton)
        {
            nextButton = true;
            prevButton = true;
            if (APIClient.MaxPages <= 0)
            {
                nextButton = false;
                prevButton = false;
            }
            if (currentPage == APIClient.MaxPages)
            {
                nextButton = false;
            }
            if (currentPage == 1)
            {
                prevButton = false;
            }
        }
    }
}