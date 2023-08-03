using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopShopApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IceCreamShopShopApp.Controllers
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
			if (!APIClient.InSystem)
			{
				return Redirect("~/Home/Enter");
			}
			return View(APIClient.GetRequest<List<ShopViewModel>>($"api/shop/getshoplist"));
		}

		public IActionResult Privacy()
		{
			if (!APIClient.InSystem)
			{
				return Redirect("~/Home/Enter");
			}
			return View();
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
		public void Enter(string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				throw new Exception("Введите пароль");
			}
			if (!APIClient.TryConnect(password))
			{
				throw new Exception("Неверный пароль");
			}
			Response.Redirect("Index");
		}
		[HttpGet]
		public IActionResult Create()
        {
            if (!APIClient.InSystem)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            return View();
		}

		[HttpPost]
		public void Create(string name, string address, int count, DateTime date)
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вы как суда попали? Суда вход только авторизованным");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("Название магазина должно быть");
			}
			if (string.IsNullOrEmpty(address))
			{
				throw new Exception("Адрес магазина должен быть");
			}
			if (date <= DateTime.MinValue)
			{
				throw new Exception("В те времена была открыта только Пятёрочка");
			}
			if (count <= 0)
			{
				throw new Exception("Вместимость магазина должна быть больше 0");
			}
			APIClient.PostRequest("api/shop/createshop", new ShopBindingModel
			{
				ShopName = name,
				MaxCountIceCreams = count,
				Address = address,
				DateOpen = date
			});
			Response.Redirect("Index");
		}
		[HttpGet]
		public IActionResult Update()
        {
            if (!APIClient.InSystem)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
			return View();
		}

		[HttpPost]
		public void Update(int shop, string name, string address, int count, DateTime date)
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вы как суда попали? Суда вход только авторизованным");
			}
			if (shop <= 0)
			{
				throw new Exception("Идентификатор магазина должен быть больше 0");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("Название магазина должно быть");
			}
			if (string.IsNullOrEmpty(address))
			{
				throw new Exception("Адрес магазина должен быть");
			}
			if (date <= DateTime.MinValue)
			{
				throw new Exception("В те времена была открыта только Пятёрочка");
			}
			if (count <= 0)
			{
				throw new Exception("Вместимость магазина должна быть больше 0");
			}
			APIClient.PostRequest("api/shop/updateshop", new ShopBindingModel
			{
				Id = shop,
				ShopName = name,
				MaxCountIceCreams = count,
				Address = address,
				DateOpen = date
			});
			Response.Redirect("Index");
		}
		[HttpGet]
		public IActionResult Delete()
        {
            if (!APIClient.InSystem)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
			return View();
		}

		[HttpPost]
		public void Delete(int shop)
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вы как суда попали? Суда вход только авторизованным");
			}
			if (shop <= 0)
			{
				throw new Exception("Идентификатор магазина должен быть больше 0");
			}
			APIClient.PostRequest("api/shop/deleteshop", new ShopBindingModel
			{
				Id = shop
			});
			Response.Redirect("Index");
		}
		[HttpGet]
		public IActionResult AddIceCream()
		{
			ViewBag.Shops = APIClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
			ViewBag.IceCreams = APIClient.GetRequest<List<IceCreamViewModel>>("api/main/geticecreamlist");
			return View();
		}

		[HttpPost]
		public void AddIceCream(int shop, int iceCream, int count)
		{
			if (!APIClient.InSystem)
			{
				throw new Exception("Вы как суда попали? Суда вход только авторизованным");
			}
			if (shop <= 0)
			{
				throw new Exception("Идентификатор магазина должен быть больше 0");
			}
			if (iceCream <= 0)
			{
				throw new Exception("Идентификатор мороженого должен быть больше 0");
			}
			if (count <= 0)
			{
				throw new Exception("Вместимость магазина должна быть больше 0");
			}
			APIClient.PostRequest("api/shop/addicecream", new Tuple<ShopSearchModel, IceCreamBindingModel, int>(new()
			{
				Id = shop
			}, new()
			{
				Id = iceCream
			}, count));
			Response.Redirect("Index");
		}
		[HttpPost]
		public Tuple<ShopViewModel,string,string> GetIceCreams(int shop)
		{
			var shopViewModel = APIClient.GetRequest<ShopViewModel>($"api/shop/getshop?shopId={shop}");
			if (shopViewModel == null)
			{
				throw new Exception("Неизвестная ошибка");
			}
			string tbody = "<td>";
			// Самый адекватный вариант перевода даты, чтобы она отображалась в инпуте
			var correctDate = shopViewModel.DateOpen.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            shopViewModel.ShopIceCreamsList.ForEach(x =>
			{
				tbody += $"<tr><td>{x.Item1.IceCreamName}</td><td>{x.Item2}</td>";
			});
			tbody += "</td>";
            return new Tuple<ShopViewModel, string, string>(shopViewModel, tbody, correctDate);
		}
	}
}