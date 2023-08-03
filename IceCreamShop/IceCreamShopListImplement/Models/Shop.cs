using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopListImplement.Models
{
    public class Shop : IShopModel
    {
        public string ShopName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DateOpen { get; set; }
        public int Id { get; set; }

        public int MaxCountIceCreams { get; set; }
        public Dictionary<int, (IIceCreamModel, int)> ShopIceCreams { get; private set; } = new Dictionary<int, (IIceCreamModel, int)>();

        public static Shop? Create(ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                ShopIceCreams = model.ShopIceCreams
            };
        }

        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            ShopIceCreams = model.ShopIceCreams;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            ShopIceCreams = ShopIceCreams
        };
    }
}
