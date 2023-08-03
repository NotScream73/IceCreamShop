using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopListImplement.Models
{
    public class IceCream : IIceCreamModel
    {
        public int Id { get; private set; }
        public string IceCreamName { get; private set; } = string.Empty;
        public double Price { get; private set; }
        public Dictionary<int, (IAdditiveModel, int)> IceCreamAdditives{ get; private set; } = new Dictionary<int, (IAdditiveModel, int)>();
        
        public static IceCream? Create(IceCreamBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new IceCream()
            {
                Id = model.Id,
                IceCreamName = model.IceCreamName,
                Price = model.Price,
                IceCreamAdditives = model.IceCreamAdditives
            };
        }

        public void Update(IceCreamBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            IceCreamName = model.IceCreamName;
            Price = model.Price;
            IceCreamAdditives = model.IceCreamAdditives;
        }

        public IceCreamViewModel GetViewModel => new()
        {
            Id = Id,
            IceCreamName = IceCreamName,
            Price = Price,
            IceCreamAdditives = IceCreamAdditives
        };
    }
}