using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly ILogger _logger;
        private readonly IMessageInfoStorage _messageInfoStorage;

        public MessageInfoLogic(ILogger<MessageInfoLogic> logger, IMessageInfoStorage messageInfoStorage)
        {
            _logger = logger;
            _messageInfoStorage = messageInfoStorage;
        }

        public bool Create(MessageInfoBindingModel model)
        {
            if (_messageInfoStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public MessageInfoViewModel? ReadElement(MessageInfoSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement.Id:{Id}", model.MessageId);
            var element = _messageInfoStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.MessageId);
            return element;
        }

        public List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model)
        {
            _logger.LogInformation("ReadList. MessageId:{MessageId}", model?.MessageId);
            var list = model == null ? _messageInfoStorage.GetFullList() : _messageInfoStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list.OrderByDescending(x => x.DateDelivery).ToList();
        }

        public bool Update(MessageInfoBindingModel model)
        {
            if (_messageInfoStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
    }
}
