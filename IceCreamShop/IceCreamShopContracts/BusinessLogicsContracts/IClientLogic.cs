using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IClientLogic
    {
        List<ClientViewModel>? ReadList(ClientSearchModel? model);
        ClientViewModel? ReadElement(ClientSearchModel model);
        bool Create(ClientBindingModel model);
        bool Update(ClientBindingModel model);
        bool Delete(ClientBindingModel model);
    }
}