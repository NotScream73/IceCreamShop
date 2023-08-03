using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.StoragesContracts
{
    public interface IShopStorage
    {
        List<ShopViewModel> GetFullList();
        List<ShopViewModel> GetFilteredList(ShopSearchModel model);
        ShopViewModel? GetElement(ShopSearchModel model);
        ShopViewModel? Insert(ShopBindingModel model);
        ShopViewModel? Update(ShopBindingModel model);
        ShopViewModel? Delete(ShopBindingModel model);
        bool SellIceCreams(IIceCreamModel model, int count);
    }
}
