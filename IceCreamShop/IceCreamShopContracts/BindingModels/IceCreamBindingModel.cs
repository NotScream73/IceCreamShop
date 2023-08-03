using IceCreamShopDataModels.Models;
using System.Text.Json.Serialization;

namespace IceCreamShopContracts.BindingModels
{
    public class IceCreamBindingModel : IIceCreamModel
    {
        public int Id { get; set; }
        public string IceCreamName { get; set; } = string.Empty;
        public double Price { get; set; }
        [JsonIgnore]
        public Dictionary<int, (IAdditiveModel, int)> IceCreamAdditives { get; set; } = new();
    }
}