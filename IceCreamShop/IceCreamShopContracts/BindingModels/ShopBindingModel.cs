using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.BindingModels
{
    public class ShopBindingModel : IShopModel
    {
        public string ShopName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOpen { get; set; } = DateTime.Now;
        public Dictionary<int, (IIceCreamModel, int)> ShopIceCreams { get; set; } = new();
        public int Id { get; set; }

        public int MaxCountIceCreams { get; set; }
    }
}