using IceCreamShopContracts.Attributes;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.ViewModels
{
    public class ShopViewModel : IShopModel
    {
        [Column(title: "Название магазина", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ShopName { get; set; } = string.Empty;

        [Column(title: "Адрес магазина", width: 75)]
        public string Address { get; set; } = string.Empty;

        [Column(title: "Дата открытия", width: 75, style: "d")]
        public DateTime DateOpen { get; set; } = DateTime.Now;
        [Column(visible: false)]
        public Dictionary<int, (IIceCreamModel iceCream, int count)> ShopIceCreams { get; set; } = new();
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(title: "Вместимость магазина", width: 75)]
        public int MaxCountIceCreams { get; set; }
        public List<Tuple<IceCreamViewModel, int>> ShopIceCreamsList { get; set; } = new();
    }
}