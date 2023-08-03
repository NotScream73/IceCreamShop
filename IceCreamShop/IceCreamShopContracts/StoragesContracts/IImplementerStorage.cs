using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.StoragesContracts
{
    public interface IImplementerStorage
    {
        List<ImplementerViewModel> GetFullList();

        List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model);

        ImplementerViewModel? GetElement(ImplementerSearchModel model);

        ImplementerViewModel? Insert(ImplementerBindingModel model);

        ImplementerViewModel? Update(ImplementerBindingModel model);

        ImplementerViewModel? Delete(ImplementerBindingModel model);
    }
}