using IceCreamShopDataModels.Enums;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.BindingModels
{
    public class OrderBindingModel : IOrderModel
    {
        public int Id { get; set; }
        public int IceCreamId { get; set; }
		public int ClientId { get; set; }
        public int? ImplementerId { get; set; }
        public int Count { get; set; }
        public double Sum { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public DateTime? DateImplement { get; set; }
    }
}