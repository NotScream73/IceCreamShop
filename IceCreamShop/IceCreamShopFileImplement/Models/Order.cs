using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Enums;
using IceCreamShopDataModels.Models;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace IceCreamShopFileImplement.Models
{
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public int IceCreamId { get; private set; }
        [DataMember]
        public int ClientId { get; private set; }
        [DataMember]
        public int? ImplementerId { get; private set; }
        [DataMember]
        public int Count { get; private set; }
        [DataMember]
        public double Sum { get; private set; }
        [DataMember]
        public OrderStatus Status { get; private set; }
        [DataMember]
        public DateTime DateCreate { get; private set; }
        [DataMember]
        public DateTime? DateImplement { get; private set; }

        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                IceCreamId = model.IceCreamId,
				ClientId = model.ClientId,
                ImplementerId = model.ImplementerId,
				Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement
            };
        }
        public static Order? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Order()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                IceCreamId = Convert.ToInt32(element.Element("IceCreamId")!.Value),
				ClientId = Convert.ToInt32(element.Element("ClientId")!.Value),
                ImplementerId = Convert.ToInt32(element.Element("ImplementerId")!.Value),
                Sum = Convert.ToDouble(element.Element("Sum")!.Value),
                Count = Convert.ToInt32(element.Element("Count")!.Value),
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), element.Element("Status")!.Value),
                DateCreate = Convert.ToDateTime(element.Element("DateCreate")!.Value),
                DateImplement = string.IsNullOrEmpty(element.Element("DateImplement")!.Value) ? null : Convert.ToDateTime(element.Element("DateImplement")!.Value)
            };
        }
        
        public void Update(OrderBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            Status = model.Status;
            DateImplement = model.DateImplement;
            ImplementerId = model.ImplementerId;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            IceCreamId = IceCreamId,
			ClientId = ClientId,
            ImplementerId = ImplementerId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
        };

        public XElement GetXElement => new("Order", new XAttribute("Id", Id), new XElement("IceCreamId", IceCreamId.ToString()), new XElement("ClientId", ClientId.ToString()), new XElement("ImplementerId", ImplementerId.ToString()), new XElement("Count", Count.ToString()), new XElement("Sum", Sum.ToString()), new XElement("Status", Status.ToString()), new XElement("DateCreate", DateCreate.ToString()), new XElement("DateImplement", DateImplement.ToString())
        );
    }
}