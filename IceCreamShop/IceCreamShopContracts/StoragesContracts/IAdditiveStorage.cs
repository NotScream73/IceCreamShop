using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.StoragesContracts
{
    public interface IAdditiveStorage
    {
        List<AdditiveViewModel> GetFullList();
        List<AdditiveViewModel> GetFilteredList(AdditiveSearchModel model);
        AdditiveViewModel? GetElement(AdditiveSearchModel model);
        AdditiveViewModel? Insert(AdditiveBindingModel model);
        AdditiveViewModel? Update(AdditiveBindingModel model);
        AdditiveViewModel? Delete(AdditiveBindingModel model);
    }
}