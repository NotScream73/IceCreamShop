using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;

namespace IceCreamShopListImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton _source;

        public MessageInfoStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            foreach (var elem in _source.MessageInfos)
            {
                if (!string.IsNullOrEmpty(model.MessageId) && model.MessageId == elem.MessageId)
                    return elem.GetViewModel;
            }
            return null;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            var result = new List<MessageInfoViewModel>();
            if (model.CurrentPage.HasValue && model.PageSize.HasValue)
            {
                for (int i = ((int)model.CurrentPage - 1) * (int)model.PageSize; i < model.PageSize * model.CurrentPage; i++)
                {
                    result.Add(_source.MessageInfos[i].GetViewModel);
                }
            }
            if (model.ClientId.HasValue)
            {
                foreach (var message in _source.MessageInfos)
                {
                    if (message.ClientId.HasValue && message.ClientId == model.ClientId)
                    {
                        result.Add(message.GetViewModel);
                    }
                }
            }
            return result;
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            var result = new List<MessageInfoViewModel>();
            foreach (var message in _source.MessageInfos)
            {
                result.Add(message.GetViewModel);
            }
            return result;
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            
            var newMessage = MessageInfo.Create(model);
            if (newMessage == null)
            {
                return null;
            }
            _source.MessageInfos.Add(newMessage);
            return newMessage.GetViewModel;
        }

        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            foreach (var message in _source.MessageInfos)
            {
                if (message.MessageId == model.MessageId)
                {
                    message.Update(model);
                    return message.GetViewModel;
                }
            }
            return null;
        }
    }
}
