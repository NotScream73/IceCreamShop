using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IAdditiveLogic
    {
        List<AdditiveViewModel>? ReadList(AdditiveSearchModel? model);
        AdditiveViewModel? ReadElement(AdditiveSearchModel model);
        bool Create(AdditiveBindingModel model);
        bool Update(AdditiveBindingModel model);
        bool Delete(AdditiveBindingModel model);
    }
}