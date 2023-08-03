using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopFileImplement.Models;

namespace IceCreamShopFileImplement.Implements
{
    public class AdditiveStorage : IAdditiveStorage
    {
        private readonly DataFileSingleton _source;

        public AdditiveStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }

        public List<AdditiveViewModel> GetFullList()
        {
            return _source.Additives.Select(x => x.GetViewModel).ToList();
        }

        public List<AdditiveViewModel> GetFilteredList(AdditiveSearchModel model)
        {
            if (string.IsNullOrEmpty(model.AdditiveName))
            {
                return new();
            }
            return _source.Additives.Where(x => x.AdditiveName.Contains(model.AdditiveName)).Select(x => x.GetViewModel).ToList();
        }

        public AdditiveViewModel? GetElement(AdditiveSearchModel model)
        {
            if (string.IsNullOrEmpty(model.AdditiveName) && !model.Id.HasValue)
            {
                return null;
            }
            return _source.Additives.FirstOrDefault(x => (!string.IsNullOrEmpty(model.AdditiveName) && x.AdditiveName == model.AdditiveName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public AdditiveViewModel? Insert(AdditiveBindingModel model)
        {
            model.Id = _source.Additives.Count > 0 ? _source.Additives.Max(x => x.Id) + 1 : 1;
            var newAdditive = Additive.Create(model);
            if (newAdditive == null)
            {
                return null;
            }
            _source.Additives.Add(newAdditive);
            _source.SaveAdditives();
            return newAdditive.GetViewModel;
        }

        public AdditiveViewModel? Update(AdditiveBindingModel model)
        {
            var additive = _source.Additives.FirstOrDefault(x => x.Id == model.Id);
            if (additive == null)
            {
                return null;
            }
            additive.Update(model);
            _source.SaveAdditives();
            return additive.GetViewModel;
        }

        public AdditiveViewModel? Delete(AdditiveBindingModel model)
        {
            var element = _source.Additives.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                _source.Additives.Remove(element);
                _source.SaveAdditives();
                return element.GetViewModel;
            }
            return null;
        }
    }
}