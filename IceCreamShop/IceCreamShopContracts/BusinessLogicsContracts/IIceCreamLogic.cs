using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IIceCreamLogic
    {
        List<IceCreamViewModel>? ReadList(IceCreamSearchModel? model);
        IceCreamViewModel? ReadElement(IceCreamSearchModel model);
        bool Create(IceCreamBindingModel model);
        bool Update(IceCreamBindingModel model);
        bool Delete(IceCreamBindingModel model);
    }
}