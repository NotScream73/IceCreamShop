using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using IceCreamShopFileImplement.Models;
using System.Net;

namespace IceCreamShopFileImplement.Implements
{
    public class ShopStorage : IShopStorage
    {
        private readonly DataFileSingleton _source;

        public ShopStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }

        public List<ShopViewModel> GetFullList()
        {
            return _source.Shops.Select(x => x.GetViewModel).ToList();
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            return _source.Shops.Where(x => x.ShopName.Contains(model.ShopName)).Select(x => x.GetViewModel).ToList();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }
            return _source.Shops.FirstOrDefault(x => (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            model.Id = _source.Shops.Count > 0 ? _source.Shops.Max(x => x.Id) + 1 : 1;
            var newShop = Shop.Create(model);
            if (newShop == null)
            {
                return null;
            }
            _source.Shops.Add(newShop);
            _source.SaveShops();
            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            var shop = _source.Shops.FirstOrDefault(x => x.ShopName.Contains(model.ShopName) || x.Id == model.Id);
            if (shop == null)
            {
                return null;
            }
            shop.Update(model);
            _source.SaveShops();
            return shop.GetViewModel;
        }

        public ShopViewModel? Delete(ShopBindingModel model)
        {
            var element = _source.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                _source.Shops.Remove(element);
                _source.SaveShops();
                return element.GetViewModel;
            }
            return null;
        }

        public bool SellIceCreams(IIceCreamModel model, int count)
        {
            if(_source.Shops.Select(x => x.ShopIceCreams.FirstOrDefault(x => x.Key == model.Id).Value.Item2).Sum() < count)
            {
                return false;
            }
            var list = _source.Shops.Where(x => x.ShopIceCreams.ContainsKey(model.Id));
            foreach(var shop in list)
            {
                if (shop.ShopIceCreams[model.Id].Item2 < count)
                {
                    count -= shop.ShopIceCreams[model.Id].Item2;
                    shop.ShopIceCreams[model.Id] = (shop.ShopIceCreams[model.Id].Item1, 0);
                }
                else
                {
                    shop.ShopIceCreams[model.Id] = (shop.ShopIceCreams[model.Id].Item1, shop.ShopIceCreams[model.Id].Item2 - count);
                    count -= count;
                }
                Update(new()
                {
                    ShopName = shop.ShopName,
                    Address = shop.Address,
                    DateOpen = shop.DateOpen,
                    MaxCountIceCreams = shop.MaxCountIceCreams,
                    ShopIceCreams = shop.ShopIceCreams
                });
                if (count == 0)
                {
                    return true;
                }
            }
            return true;
        }
    }
}
