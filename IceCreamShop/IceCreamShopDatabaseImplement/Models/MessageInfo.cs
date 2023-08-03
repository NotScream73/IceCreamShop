using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IceCreamShopDatabaseImplement.Models
{
    [DataContract]
    public class MessageInfo : IMessageInfoModel
    {
        [DataMember]
        [Key]
        public string MessageId { get; set; } = string.Empty;

        [DataMember]
        public int? ClientId { get; set; }
        [DataMember]
        [Required]
        public string SenderName { get; set; } = string.Empty;
        [DataMember]
        [Required]
        public DateTime DateDelivery { get; set; } = DateTime.Now;
        [DataMember]
        [Required]
        public string Subject { get; set; } = string.Empty;
        [DataMember]
        [Required]
        public string Body { get; set; } = string.Empty;
        [Required]
        public bool HasRead { get; set; }

        public string? Answer { get; set; }
        public virtual Client? Client { get; set; }

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

        public void Update(MessageInfoBindingModel model)
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
