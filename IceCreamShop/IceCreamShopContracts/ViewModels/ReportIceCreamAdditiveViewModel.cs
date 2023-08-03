namespace IceCreamShopContracts.ViewModels
{
    public class ReportIceCreamAdditiveViewModel
    {
        public string IceCreamName { get; set; } = string.Empty;

        public int TotalCount { get; set; }

        public List<(string Additive, int Count)> Additives { get; set; } = new();
    }
}
