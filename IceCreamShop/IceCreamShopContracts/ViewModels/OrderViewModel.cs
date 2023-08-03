using IceCreamShopContracts.Attributes;
using IceCreamShopDataModels.Enums;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.ViewModels
{
    public class OrderViewModel : IOrderModel
    {
        [Column(title: "Номер", width: 75)]
        public int Id { get; set; }

        [Column(visible: false)]
        public int IceCreamId { get; set; }

        [Column(title: "Мороженое", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string IceCreamName { get; set; } = string.Empty;

        [Column(visible: false)]
        public int ClientId { get; set; }
        [Column(title: "Клиент", width: 100)]
        public string ClientFIO { get; set; } = string.Empty;

        [Column(visible: false)]
        public int? ImplementerId { get; set; }
        [Column(title: "Исполнитель", width: 100)]
        public string ImplementerFIO { get; set; } = string.Empty;

        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 100, style: "c2")]
        public double Sum { get; set; }

        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;

        [Column(title: "Дата создания", width: 100, style: "d")]
        public DateTime DateCreate { get; set; } = DateTime.Now;

        [Column(title: "Дата выполнения", width: 100, style: "d")]
        public DateTime? DateImplement { get; set; }
	}
}