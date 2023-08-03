using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopListImplement.Models
{
    public class MessageInfo : IMessageInfoModel
    {
        public string MessageId { get; private set; } = string.Empty;

        public int? ClientId { get; private set; }

        public string SenderName { get; private set; } = string.Empty;

        public DateTime DateDelivery { get; private set; } = DateTime.Now;

        public string Subject { get; private set; } = string.Empty;

        public string Body { get; private set; } = string.Empty;

        public bool HasRead { get; private set; }

        public string? Answer { get; private set; }

        public static MessageInfo? Create(MessageInfoBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new MessageInfo()
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId,
                SenderName = model.SenderName,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                HasRead = model.HasRead,
                Answer = model.Answer
            };
        }

        public void Update(MessageInfoBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            HasRead = model.HasRead;
            Answer = model.Answer;
        }

        public MessageInfoViewModel GetViewModel => new()
        {
            MessageId = MessageId,
            ClientId = ClientId,
            SenderName = SenderName,
            DateDelivery = DateDelivery,
            Subject = Subject,
            Body = Body,
            HasRead = HasRead,
            Answer = Answer
        };

        public int Id => throw new NotImplementedException();
    }
}
