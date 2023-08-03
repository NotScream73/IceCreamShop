using IceCreamShopContracts.Attributes;
using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.ViewModels
{
    public class ImplementerViewModel : IImplementerModel
    {

        [Column(visible: false)]
        public int Id { get; set; }

        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ImplementerFIO { get; set; } = string.Empty;

        [Column(title: "Пароль", width: 75)]
        public string Password { get; set; } = string.Empty;

        [Column(title: "Стаж работы", width: 75)]
        public int WorkExperience { get; set; }

        [Column(title: "Квалификация", width: 75)]
        public int Qualification { get; set; }
    }
}