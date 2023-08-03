using IceCreamShopDataModels.Enums;

namespace IceCreamShopContracts.SearchModels
{
    public class OrderSearchModel
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public int? ImplementerId { get; set; }
        public OrderStatus? Status { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
