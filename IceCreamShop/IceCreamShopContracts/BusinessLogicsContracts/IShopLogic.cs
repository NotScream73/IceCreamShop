using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IShopLogic
    {
        List<ShopViewModel>? ReadList(ShopSearchModel? model);
        ShopViewModel? ReadElement(ShopSearchModel model);
        bool Create(ShopBindingModel model);
        bool Update(ShopBindingModel model);
        bool Delete(ShopBindingModel model);
        bool AddIceCream(ShopSearchModel model, IIceCreamModel iceCream, int count);
        bool SellIceCreams(IIceCreamModel model, int count);
        bool AddIceCreams(IIceCreamModel model, int count);
    }
}