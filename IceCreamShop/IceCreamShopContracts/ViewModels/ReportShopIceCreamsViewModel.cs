namespace IceCreamShopContracts.ViewModels
{
    public class ReportShopIceCreamsViewModel
    {
        public string ShopName { get; set; } = string.Empty;

        public int TotalCount { get; set; }

        public List<(string IceCream, int Count)> IceCreams { get; set; } = new();
    }
}
