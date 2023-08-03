using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;

namespace IceCreamShopListImplement.Implements
{
    internal class ImplementerStorage : IImplementerStorage
    {
        private readonly DataListSingleton _source;

        public ImplementerStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public ImplementerViewModel? Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < _source.Implementers.Count; ++i)
            {
                if (_source.Implementers[i].Id == model.Id)
                {
                    var element = _source.Implementers[i];
                    _source.Implementers.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }

        public ImplementerViewModel? GetElement(ImplementerSearchModel model)
        {
            foreach (var elem in _source.Implementers)
            {
                if (model.Id.HasValue && model.Id == elem.Id)
                    return elem.GetViewModel;
                if (!string.IsNullOrEmpty(model.ImplementerFIO) && !string.IsNullOrEmpty(model.Password) && elem.ImplementerFIO == model.ImplementerFIO && elem.Password == model.Password)
                    return elem.GetViewModel;
                if (!string.IsNullOrEmpty(model.ImplementerFIO) && model.ImplementerFIO == elem.ImplementerFIO)
                    return elem.GetViewModel;
            }
            return null;
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
        {
            var result = new List<ImplementerViewModel>();

            if (string.IsNullOrEmpty(model.ImplementerFIO) && !model.Id.HasValue)
            {
                return result;
            }
            if (model.Id.HasValue)
            {
                var implementer = GetElement(model);
                return implementer == null ? result : new() { implementer };
            }
            if (!string.IsNullOrEmpty(model.ImplementerFIO))
            {
                foreach (var implementer in _source.Implementers)
                {
                    if (implementer.ImplementerFIO.Contains(model.ImplementerFIO))
                    {
                        result.Add(implementer.GetViewModel);
                    }
                }
            }
            return result;
        }

        public List<ImplementerViewModel> GetFullList()
        {
            var result = new List<ImplementerViewModel>();
            foreach (var implementer in _source.Implementers)
            {
                result.Add(implementer.GetViewModel);
            }
            return result;
        }

        public ImplementerViewModel? Insert(ImplementerBindingModel model)
        {
            model.Id = 1;
            foreach (var implementer in _source.Implementers)
            {
                if (model.Id <= implementer.Id)
                {
                    model.Id = implementer.Id + 1;
                }
            }
            var newImplementer = Implementer.Create(model);
            if (newImplementer == null)
            {
                return null;
            }
            _source.Implementers.Add(newImplementer);
            return newImplementer.GetViewModel;
        }

        public ImplementerViewModel? Update(ImplementerBindingModel model)
        {
            foreach (var implementer in _source.Implementers)
            {
                if (implementer.Id == model.Id)
                {
                    implementer.Update(model);
                    return implementer.GetViewModel;
                }
            }
            return null;
        }
    }
}