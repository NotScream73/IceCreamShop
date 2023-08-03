using IceCreamShopDataModels.Enums;

namespace IceCreamShopContracts.ViewModels
{
    public class ReportOrdersViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string IceCreamName { get; set; } = string.Empty;
        public double Sum { get; set; }
        public string OrderStatus { get; set; }
    }
}
