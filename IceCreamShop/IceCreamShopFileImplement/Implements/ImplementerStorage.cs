using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopFileImplement.Models;

namespace IceCreamShopFileImplement.Implements
{
    internal class ImplementerStorage : IImplementerStorage
    {
        private readonly DataFileSingleton _source;

        public ImplementerStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }
        public ImplementerViewModel? Delete(ImplementerBindingModel model)
        {
            var element = _source.Implementers.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                _source.Implementers.Remove(element);
                _source.SaveImplementers();
                return element.GetViewModel;
            }
            return null;
        }

        public ImplementerViewModel? GetElement(ImplementerSearchModel model)
        {
            if (model.Id.HasValue)
                return _source.Implementers
                              .FirstOrDefault(x => x.Id == model.Id)
                              ?.GetViewModel;
            if (!string.IsNullOrEmpty(model.ImplementerFIO) && !string.IsNullOrEmpty(model.Password))
                return _source.Implementers
                              .FirstOrDefault(x => x.ImplementerFIO == model.ImplementerFIO && x.Password == model.Password)
                              ?.GetViewModel;
            if (!string.IsNullOrEmpty(model.ImplementerFIO))
                return _source.Implementers
                              .FirstOrDefault(x => x.ImplementerFIO == model.ImplementerFIO)
                              ?.GetViewModel;
            return null;
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ImplementerFIO) && !model.Id.HasValue)
            {
                return new();
            }
            if (model.Id.HasValue)
            {
                var implementer = GetElement(model);
                return implementer == null ? new() : new() { implementer };
            }
            if (!string.IsNullOrEmpty(model.ImplementerFIO))
            {
                return _source.Implementers
                        .Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO))
                        .Select(x => x.GetViewModel)
                        .ToList();
            }
            return new();
        }

        public List<ImplementerViewModel> GetFullList()
        {
            return _source.Implementers.Select(x => x.GetViewModel).ToList();
        }

        public ImplementerViewModel? Insert(ImplementerBindingModel model)
        {
            model.Id = _source.Implementers.Count > 0 ? _source.Implementers.Max(x => x.Id) + 1 : 1;
            var newImplementer = Implementer.Create(model);
            if (newImplementer == null)
            {
                return null;
            }
            _source.Implementers.Add(newImplementer);
            _source.SaveImplementers();
            return newImplementer.GetViewModel;
        }

        public ImplementerViewModel? Update(ImplementerBindingModel model)
        {
            var implementer = _source.Implementers.FirstOrDefault(x => x.Id == model.Id);
            if (implementer == null)
            {
                return null;
            }
            implementer.Update(model);
            _source.SaveImplementers();
            return implementer.GetViewModel;
        }
    }
}