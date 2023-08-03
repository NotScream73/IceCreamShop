namespace IceCreamShopContracts.SearchModels
{
    public class MessageInfoSearchModel
    {
        public int? ClientId { get; set; }

        public string? MessageId { get; set; }
        public int? PageSize { get; set; }
        public int? CurrentPage { get; set; }
    }
}