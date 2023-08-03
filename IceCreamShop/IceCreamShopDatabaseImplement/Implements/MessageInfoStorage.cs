using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            using var context = new IceCreamShopDatabase();
            return context.MessageInfos
                    .FirstOrDefault(x => !string.IsNullOrEmpty(x.MessageId) && x.MessageId == model.MessageId)
                    ?.GetViewModel;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            using var context = new IceCreamShopDatabase();
            if (model.CurrentPage.HasValue && model.PageSize.HasValue && model.ClientId.HasValue)
            {
                return context.MessageInfos.Where(x => x.ClientId == model.ClientId).Skip((int)((model.CurrentPage - 1) * model.PageSize)).Take((int)model.PageSize).Select(x => x.GetViewModel).ToList();
            }
            if (model.CurrentPage.HasValue && model.PageSize.HasValue)
            {
                return context.MessageInfos.Skip((int)((model.CurrentPage - 1) * model.PageSize)).Take((int)model.PageSize).Select(x => x.GetViewModel).ToList();
            }
            return context.MessageInfos
                    .Where(x => x.ClientId.HasValue && x.ClientId == model.ClientId)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new IceCreamShopDatabase();
            return context.MessageInfos
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var newMessage = MessageInfo.Create(model);
            if (newMessage == null)
            {
                return null;
            }
            context.MessageInfos.Add(newMessage);
            context.SaveChanges();
            return newMessage.GetViewModel;
        }

        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var message = context.MessageInfos.FirstOrDefault(x => x.MessageId == model.MessageId);
            if (message == null)
            {
                return null;
            }
            message.Update(model);
            context.SaveChanges();
            return message.GetViewModel;
        }
    }
}
