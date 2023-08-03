using IceCreamShopContracts.ViewModels;

namespace IceCreamShopBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<IceCreamViewModel> IceCreams { get; set; } = new();

        public List<ShopViewModel> Shops { get; set; } = new();
    }
}
