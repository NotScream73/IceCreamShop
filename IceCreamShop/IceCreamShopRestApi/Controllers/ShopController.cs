using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly ILogger _logger;

        private readonly IShopLogic _shop;

        public ShopController(ILogger<ShopController> logger, IShopLogic shop)
        {
            _logger = logger;
            _shop = shop;
        }

        [HttpGet]
        public List<ShopViewModel>? GetShopList()
        {
            try
            {
                return _shop.ReadList(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка магазинов");
                throw;
            }
        }

        [HttpGet]
        public ShopViewModel? GetShop(int shopId)
        {
            try
            {
                return _shop.ReadElement(new ShopSearchModel { Id = shopId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения магазина по id={Id}", shopId);
                throw;
            }
        }
        [HttpPost]
        public void CreateShop(ShopBindingModel model)
        {
            try
            {
                _shop.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания магазина");
                throw;
            }
        }

        [HttpPost]
        public void UpdateShop(ShopBindingModel model)
        {
            try
            {
                _shop.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления магазина");
                throw;
            }
        }

        [HttpPost]
        public void DeleteShop(ShopBindingModel model)
        {
            try
            {
                _shop.Delete(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления магазина");
                throw;
            }
        }
        [HttpPost]
        public void AddIceCream(Tuple<ShopSearchModel,IceCreamBindingModel,int> model)
        {
            try
            {
                _shop.AddIceCream(model.Item1,model.Item2,model.Item3);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка добавления мороженого в магазин");
                throw;
            }
        }
    }
}