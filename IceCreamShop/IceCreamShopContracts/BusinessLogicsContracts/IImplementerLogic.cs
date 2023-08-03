using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel>? ReadList(ImplementerSearchModel? model);

        ImplementerViewModel? ReadElement(ImplementerSearchModel model);

        bool Create(ImplementerBindingModel model);

        bool Update(ImplementerBindingModel model);

        bool Delete(ImplementerBindingModel model);
    }
}