using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.StoragesContracts
{
    public interface IIceCreamStorage
    {
        List<IceCreamViewModel> GetFullList();
        List<IceCreamViewModel> GetFilteredList(IceCreamSearchModel model);
        IceCreamViewModel? GetElement(IceCreamSearchModel model);
        IceCreamViewModel? Insert(IceCreamBindingModel model);
        IceCreamViewModel? Update(IceCreamBindingModel model);
        IceCreamViewModel? Delete(IceCreamBindingModel model);
    }
}