using IceCreamShopContracts.Attributes;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.ViewModels
{
    public class IceCreamViewModel : IIceCreamModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "Название мороженого", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string IceCreamName { get; set; } = string.Empty;

        [Column(title: "Цена", width: 150, style: "c2")]
        public double Price { get; set; }
        [Column(visible: false)]
        public Dictionary<int, (IAdditiveModel, int)> IceCreamAdditives { get; set; } = new();
    }
}