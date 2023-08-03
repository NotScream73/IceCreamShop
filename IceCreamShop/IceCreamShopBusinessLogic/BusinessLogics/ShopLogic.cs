using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using Microsoft.Extensions.Logging;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class ShopLogic : IShopLogic
    {
        private readonly ILogger _logger;
        private readonly IShopStorage _shopStorage;

        public ShopLogic(ILogger<ShopLogic> logger, IShopStorage shopStorage)
        {
            _logger = logger;
            _shopStorage = shopStorage;
        }

        public ShopViewModel? ReadElement(ShopSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ShopName:{ShopName}. Id:{Id}", model.ShopName, model.Id);
            var element = _shopStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public List<ShopViewModel>? ReadList(ShopSearchModel? model)
        {
            _logger.LogInformation("ReadList. ShopName:{ShopName}. Id: {Id}", model?.ShopName, model?.Id);
            var list = model == null ? _shopStorage.GetFullList() : _shopStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public bool Create(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(ShopBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_shopStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        public bool Update(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool AddIceCream(ShopSearchModel model, IIceCreamModel iceCream, int count)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (count <= 0)
            {
                throw new ArgumentNullException("Количество добавляемого мороженого должно быть больше 0", nameof(count));
            }
            _logger.LogInformation("AddIceCream. ShopName:{ShopName}. Id: {Id}", model?.ShopName, model?.Id);
            var shop = _shopStorage.GetElement(model);
            if (shop == null)
            {
                _logger.LogWarning("Add IceCream operation failed");
                return false;
            }
            if (shop.MaxCountIceCreams - shop.ShopIceCreams.Select(x => x.Value.Item2).Sum() < count)
            {
                throw new ArgumentNullException("Слишком много мороженого для одного магазина", nameof(count));
            }
            if (!shop.ShopIceCreams.ContainsKey(iceCream.Id))
            {
                shop.ShopIceCreams[iceCream.Id] = (iceCream, count);
            }
            else
            {
                shop.ShopIceCreams[iceCream.Id] = (iceCream, shop.ShopIceCreams[iceCream.Id].Item2 + count);
            }
            _shopStorage.Update(new ShopBindingModel()
            {
                Id = shop.Id,
                ShopName = shop.ShopName,
                Address = shop.Address,
                DateOpen = shop.DateOpen,
                MaxCountIceCreams = shop.MaxCountIceCreams,
                ShopIceCreams = shop.ShopIceCreams
            });
            return true;
        }

        private void CheckModel(ShopBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ShopName))
            {
                throw new ArgumentNullException("Нет названия магазина", nameof(model.ShopName));
            }
            if (string.IsNullOrEmpty(model.Address))
            {
                throw new ArgumentNullException("Нет адреса магазина", nameof(model.Address));
            }
            _logger.LogInformation("Shop. ShopName:{ShopName}. Address:{Address}. Id: {Id}", model.ShopName, model.Address, model.Id);
            var element = _shopStorage.GetElement(new ShopSearchModel
            {
                ShopName = model.ShopName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Магазин с таким названием уже есть");
            }
        }
        
        public bool AddIceCreams(IIceCreamModel model, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentNullException("Количество добавляемого мороженого должно быть больше 0", nameof(count));
            }
            _logger.LogInformation("AddIceCreams. IceCream: {IceCream}. Count: {Count}", model?.IceCreamName, count);
            var capacity = _shopStorage.GetFullList().Select(x => x.MaxCountIceCreams - x.ShopIceCreams.Select(x => x.Value.Item2).Sum()).Sum() - count;
            if (capacity < 0)
            {
                _logger.LogWarning("AddIceCreams operation failed. Sell {count} Ice Creams ", -capacity);
                return false;
            }
            foreach(var shop in _shopStorage.GetFullList())
            {
                if (shop.MaxCountIceCreams - shop.ShopIceCreams.Select(x => x.Value.Item2).Sum() == 0)
                {
                    continue;
                }
                if (shop.MaxCountIceCreams - shop.ShopIceCreams.Select(x => x.Value.Item2).Sum() < count)
                {
                    if (!AddIceCream(new() { Id = shop.Id}, model, shop.MaxCountIceCreams - shop.ShopIceCreams.Select(x => x.Value.Item2).Sum()))
                    {
                        _logger.LogWarning("AddIceCreams operation failed.");
                        return false;
                    }
                    count -= shop.MaxCountIceCreams - shop.ShopIceCreams.Select(x => x.Value.Item2).Sum();
                }
                else
                {
                    if (!AddIceCream(new() { Id = shop.Id }, model, count))
                    {
                        _logger.LogWarning("AddIceCreams operation failed.");
                        return false;
                    }
                    count -= count;
                }
                if (count == 0)
                {
                    return true;
                }
            }
            return true;
        }
        public bool SellIceCreams(IIceCreamModel model, int count)
        {
            return _shopStorage.SellIceCreams(model, count);
        }
    }
}