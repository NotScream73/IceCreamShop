using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopFileImplement.Models;

namespace IceCreamShopFileImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataFileSingleton _source;

        public MessageInfoStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            if (!string.IsNullOrEmpty(model.MessageId))
            {
                return _source.MessageInfos
                              .FirstOrDefault(x => x.MessageId == model.MessageId)
                              ?.GetViewModel;
            }
            return null;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            if (model.CurrentPage.HasValue && model.PageSize.HasValue)
            {
                return _source.MessageInfos
                        .Skip((int)((model.CurrentPage - 1) * model.PageSize))
                        .Take((int)model.PageSize)
                        .Select(x => x.GetViewModel)
                        .ToList();
            }
            if (model.ClientId.HasValue)
            {
                return _source.MessageInfos
                        .Where(x => x.ClientId == model.ClientId)
                        .Select(x => x.GetViewModel)
                        .ToList();
            }
            return new();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            return _source.MessageInfos.Select(x => x.GetViewModel).ToList();
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            var newMessage = MessageInfo.Create(model);
            if (newMessage == null)
            {
                return null;
            }
            _source.MessageInfos.Add(newMessage);
            _source.SaveClients();
            return newMessage.GetViewModel;
        }

        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            var message = _source.MessageInfos.FirstOrDefault(x => x.MessageId == model.MessageId);
            if (message == null)
            {
                return null;
            }
            message.Update(model);
            _source.SaveClients();
            return message.GetViewModel;
        }
    }
}
