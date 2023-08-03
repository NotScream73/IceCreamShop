using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class IceCreamLogic : IIceCreamLogic
    {
        private readonly ILogger _logger;
        private readonly IIceCreamStorage _iceCreamStorage;

        public IceCreamLogic(ILogger<IceCreamLogic> logger, IIceCreamStorage iceCreamStorage)
        {
            _logger = logger;
            _iceCreamStorage = iceCreamStorage;
        }

        public List<IceCreamViewModel>? ReadList(IceCreamSearchModel? model)
        {
            _logger.LogInformation("ReadList. IceCreamName:{IceCreamName}.Id:{Id}", model?.IceCreamName, model?.Id);
            var list = model == null ? _iceCreamStorage.GetFullList() : _iceCreamStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public IceCreamViewModel? ReadElement(IceCreamSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. IceCreamName:{IceCreamName}. Id:{Id}", model.IceCreamName, model.Id);
            var element = _iceCreamStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(IceCreamBindingModel model)
        {
            CheckModel(model);
            if (_iceCreamStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(IceCreamBindingModel model)
        {
            CheckModel(model);
            if (_iceCreamStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(IceCreamBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_iceCreamStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(IceCreamBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.IceCreamName))
            {
                throw new ArgumentNullException("Нет названия мороженого", nameof(model.IceCreamName));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentNullException("Цена мороженого должна быть больше 0", nameof(model.Price));
            }
            _logger.LogInformation("IceCream. IceCreamName:{IceCreamName}. Cost:{Cost}. Id: {Id}", model.IceCreamName, model.Price, model.Id);
            var element = _iceCreamStorage.GetElement(new IceCreamSearchModel
            {
                IceCreamName = model.IceCreamName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Мороженое с таким названием уже есть");
            }
        }
    }
}