using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopListImplement.Models
{
    public class Additive : IAdditiveModel
    {
        public int Id { get; private set; }
        public string AdditiveName { get; private set; } = string.Empty;
        public double Cost { get; set; }

        public static Additive? Create(AdditiveBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Additive()
            {
                Id = model.Id,
                AdditiveName = model.AdditiveName,
                Cost = model.Cost
            };
        }

        public void Update(AdditiveBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            AdditiveName = model.AdditiveName;
            Cost = model.Cost;
        }

        public AdditiveViewModel GetViewModel => new()
        {
            Id = Id,
            AdditiveName = AdditiveName,
            Cost = Cost
        };
    }
}