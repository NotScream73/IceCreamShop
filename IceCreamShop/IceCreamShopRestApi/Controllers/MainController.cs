using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly ILogger _logger;

        private readonly IOrderLogic _order;

        private readonly IIceCreamLogic _iceCream;

        public MainController(ILogger<MainController> logger, IOrderLogic order, IIceCreamLogic iceCream)
        {
            _logger = logger;
            _order = order;
            _iceCream = iceCream;
        }

        [HttpGet]
        public List<IceCreamViewModel>? GetIceCreamList()
        {
            try
            {
                return _iceCream.ReadList(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка мороженого");
                throw;
            }
        }

        [HttpGet]
        public IceCreamViewModel? GetIceCream(int iceCreamId)
        {
            try
            {
                return _iceCream.ReadElement(new IceCreamSearchModel { Id = iceCreamId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения мороженого по id={Id}", iceCreamId);
                throw;
            }
        }

        [HttpGet]
        public List<OrderViewModel>? GetOrders(int clientId)
        {
            try
            {
                return _order.ReadList(new OrderSearchModel { ClientId = clientId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка заказов клиента id={Id}", clientId);
                throw;
            }
        }

        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            try
            {
                _order.CreateOrder(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                throw;
            }
        }
    }
}
