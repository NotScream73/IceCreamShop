using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Enums;
using IceCreamShopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IceCreamShopDatabaseImplement.Models
{
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        [Required]
        public int IceCreamId { get; set; }
        [DataMember]
        [Required]
		public int ClientId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        [Required]
        public int Count { get; set; }
        [DataMember]
        [Required]
        public double Sum { get; set; }
        [DataMember]
        [Required]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Required]
        public DateTime DateCreate { get; set; }
        [DataMember]

        public DateTime? DateImplement { get; set; }

        [DataMember]
        public int Id { get; set; }
        public virtual IceCream IceCream { get; set; }
		public virtual Client Client { get; set; }
        public virtual Implementer? Implementer { get; set; }
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
            IceCreamName = IceCream.IceCreamName,
			ClientFIO = Client.ClientFIO,
            ImplementerFIO = Implementer == null ? null : Implementer.ImplementerFIO
		};
    }
}