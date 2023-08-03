using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;

namespace IceCreamShopListImplement.Implements
{
    public class AdditiveStorage : IAdditiveStorage
    {
        private readonly DataListSingleton _source;

        public AdditiveStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public List<AdditiveViewModel> GetFullList()
        {
            var result = new List<AdditiveViewModel>();
            foreach (var additive in _source.Additives)
            {
                result.Add(additive.GetViewModel);
            }
            return result;
        }

        public List<AdditiveViewModel> GetFilteredList(AdditiveSearchModel model)
        {
            var result = new List<AdditiveViewModel>();
            if (string.IsNullOrEmpty(model.AdditiveName))
            {
                return result;
            }
            foreach (var additive in _source.Additives)
            {
                if (additive.AdditiveName.Contains(model.AdditiveName))
                {
                    result.Add(additive.GetViewModel);
                }
            }
            return result;
        }

        public AdditiveViewModel? GetElement(AdditiveSearchModel model)
        {
            if (string.IsNullOrEmpty(model.AdditiveName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var additive in _source.Additives) 
            {
                if ((!string.IsNullOrEmpty(model.AdditiveName) && additive.AdditiveName == model.AdditiveName) || (model.Id.HasValue && additive.Id == model.Id))
                {
                    return additive.GetViewModel;
                }
            }
            return null;
        }

        public AdditiveViewModel? Insert(AdditiveBindingModel model)
        {
            model.Id = 1;
            foreach (var additive in _source.Additives)
            {
                if (model.Id <= additive.Id)
                {
                    model.Id = additive.Id + 1;
                }
            }
            var newAdditive = Additive.Create(model);
            if (newAdditive == null)
            {
                return null;
            }
            _source.Additives.Add(newAdditive);
            return newAdditive.GetViewModel;
        }

        public AdditiveViewModel? Update(AdditiveBindingModel model)
        {
            foreach (var additive in _source.Additives)
            {
                if (additive.Id == model.Id)
                {
                    additive.Update(model);
                    return additive.GetViewModel;
                }
            }
            return null;
        }

        public AdditiveViewModel? Delete(AdditiveBindingModel model)
        {
            for (int i = 0; i < _source.Additives.Count; ++i)
            {
                if (_source.Additives[i].Id == model.Id)
                {
                    var element = _source.Additives[i];
                    _source.Additives.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}