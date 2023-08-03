using IceCreamShopContracts.ViewModels;

namespace IceCreamShopBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<ReportIceCreamAdditiveViewModel> IceCreamAdditives
        {
            get;
            set;
        } = new();
        public List<ReportShopIceCreamsViewModel> ShopIceCreams
        {
            get;
            set;
        } = new();
    }
}
