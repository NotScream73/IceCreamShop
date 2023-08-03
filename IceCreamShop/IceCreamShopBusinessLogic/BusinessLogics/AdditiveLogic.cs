using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class AdditiveLogic : IAdditiveLogic
    {
        private readonly ILogger _logger;
        private readonly IAdditiveStorage _additiveStorage;

        public AdditiveLogic(ILogger<AdditiveLogic> logger, IAdditiveStorage additiveStorage)
        {
            _logger = logger;
            _additiveStorage = additiveStorage;
        }

        public List<AdditiveViewModel>? ReadList(AdditiveSearchModel? model)
        {
            _logger.LogInformation("ReadList. AdditiveName:{AdditiveName}. Id:{Id}", model?.AdditiveName, model?.Id);
            var list = model == null ? _additiveStorage.GetFullList() : _additiveStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public AdditiveViewModel? ReadElement(AdditiveSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. AdditiveName:{AdditiveName}. Id:{Id}", model.AdditiveName, model.Id);
            var element = _additiveStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(AdditiveBindingModel model)
        {
            CheckModel(model);
            if (_additiveStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(AdditiveBindingModel model)
        {
            CheckModel(model);
            if (_additiveStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(AdditiveBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_additiveStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(AdditiveBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.AdditiveName))
            {
                throw new ArgumentNullException("Нет названия добавки", nameof(model.AdditiveName));
            }
            if (model.Cost <= 0)
            {
                throw new ArgumentNullException("Цена добавки должна быть больше 0", nameof(model.Cost));
            }
            _logger.LogInformation("Additive. AdditiveName:{AdditiveName}. Cost:{Cost}. Id: {Id}", model.AdditiveName, model.Cost, model.Id);
            var element = _additiveStorage.GetElement(new AdditiveSearchModel
            {
                AdditiveName = model.AdditiveName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Добавка с таким названием уже есть");
            }
        }
    }
}