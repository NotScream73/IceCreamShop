using IceCreamShopContracts.Attributes;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.ViewModels
{
    public class AdditiveViewModel : IAdditiveModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "Название добавки", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string AdditiveName { get; set; } = string.Empty;

        [Column(title: "Цена", width: 150, style: "c2")]
        public double Cost { get; set; }
    }
}