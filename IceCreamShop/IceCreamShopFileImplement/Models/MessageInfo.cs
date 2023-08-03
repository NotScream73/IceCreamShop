using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace IceCreamShopFileImplement.Models
{
    [DataContract]
    public class MessageInfo : IMessageInfoModel
    {
        [DataMember]
        public string MessageId { get; set; } = string.Empty;

        [DataMember]
        public int? ClientId { get; set; }

        [DataMember]
        public string SenderName { get; set; } = string.Empty;

        [DataMember]
        public DateTime DateDelivery { get; set; } = DateTime.Now;

        [DataMember]
        public string Subject { get; set; } = string.Empty;

        [DataMember]
        public string Body { get; set; } = string.Empty;
        [DataMember]
        public bool HasRead { get; set; }
        [DataMember]
        public string? Answer { get; set; }

        public static MessageInfo? Create(MessageInfoBindingModel model)
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
                Body = model.Body
            };
        }

        public static MessageInfo? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new MessageInfo()
            {
                MessageId = element.Element("MessageId")!.Value,
                ClientId = Convert.ToInt32(element.Element("ClientId")!.Value),
                SenderName = element.Element("MessageId")!.Value,
                DateDelivery = DateTime.ParseExact(element.Element("DateDelivery")!.Value, "G", null),
                Subject = element.Element("MessageId")!.Value,
                Body = element.Element("MessageId")!.Value
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

        public XElement GetXElement => new("MessageInfo", new XAttribute("MessageId", MessageId), new XElement("ClientId", ClientId), new XElement("SenderName", SenderName), new XElement("DateDelivery", DateDelivery), new XElement("Subject", Subject), new XElement("Body", Body));

        public int Id => throw new NotImplementedException();
    }
}