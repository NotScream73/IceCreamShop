using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model);

        MessageInfoViewModel? ReadElement(MessageInfoSearchModel model);
        
        bool Create(MessageInfoBindingModel model);

        bool Update(MessageInfoBindingModel model);
    }
}