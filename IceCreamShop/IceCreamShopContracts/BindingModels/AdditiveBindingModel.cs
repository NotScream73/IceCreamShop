using IceCreamShopDataModels.Models;

namespace IceCreamShopContracts.BindingModels
{
    public class AdditiveBindingModel : IAdditiveModel
    {
        public int Id { get; set; }
        public string AdditiveName { get; set; } = string.Empty;
        public double Cost { get; set; }
    }
}