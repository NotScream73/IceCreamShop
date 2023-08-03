using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Enums;
using IceCreamShopDataModels.Models;

namespace IceCreamShopListImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }
        public int IceCreamId { get; private set; }
		public int ClientId { get; private set; }
        public int? ImplementerId { get; private set; }
        public int Count { get; private set; }
        public double Sum { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime DateCreate { get; private set; }
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

        public void Update(OrderBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            IceCreamId = model.IceCreamId;
            ClientId = model.ClientId;
            ImplementerId = model.ImplementerId;
            Count = model.Count;
            Sum = model.Sum;
            Status = model.Status;
            DateCreate = model.DateCreate;
            DateImplement = model.DateImplement;
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
            DateImplement = DateImplement
        };

	}
}