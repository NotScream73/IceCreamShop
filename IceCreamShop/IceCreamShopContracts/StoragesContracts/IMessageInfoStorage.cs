using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.StoragesContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();

        List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model);

        MessageInfoViewModel? GetElement(MessageInfoSearchModel model);

        MessageInfoViewModel? Insert(MessageInfoBindingModel model);

        MessageInfoViewModel? Update(MessageInfoBindingModel model);
    }
}