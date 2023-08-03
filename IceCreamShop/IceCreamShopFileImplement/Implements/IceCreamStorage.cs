using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopFileImplement.Models;

namespace IceCreamShopFileImplement.Implements
{
    public class IceCreamStorage : IIceCreamStorage
    {
        private readonly DataFileSingleton _source;

        public IceCreamStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }

        public List<IceCreamViewModel> GetFullList()
        {
            return _source.IceCreams.Select(x => x.GetViewModel).ToList();
        }

        public List<IceCreamViewModel> GetFilteredList(IceCreamSearchModel model)
        {
            if (string.IsNullOrEmpty(model.IceCreamName))
            {
                return new();
            }
            return _source.IceCreams.Where(x => x.IceCreamName.Contains(model.IceCreamName)).Select(x => x.GetViewModel).ToList();
        }

        public IceCreamViewModel? GetElement(IceCreamSearchModel model)
        {
            if (string.IsNullOrEmpty(model.IceCreamName) && !model.Id.HasValue)
            {
                return null;
            }
            return _source.IceCreams.FirstOrDefault(x => (!string.IsNullOrEmpty(model.IceCreamName) && x.IceCreamName == model.IceCreamName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public IceCreamViewModel? Insert(IceCreamBindingModel model)
        {
            model.Id = _source.IceCreams.Count > 0 ? _source.IceCreams.Max(x => x.Id) + 1 : 1;
            var newIceCream = IceCream.Create(model);
            if (newIceCream == null)
            {
                return null;
            }
            _source.IceCreams.Add(newIceCream);
            _source.SaveIceCreams();
            return newIceCream.GetViewModel;
        }

        public IceCreamViewModel? Update(IceCreamBindingModel model)
        {
            var iceCream = _source.IceCreams.FirstOrDefault(x => x.Id == model.Id);
            if (iceCream == null)
            {
                return null;
            }
            iceCream.Update(model);
            _source.SaveIceCreams();
            return iceCream.GetViewModel;
        }

        public IceCreamViewModel? Delete(IceCreamBindingModel model)
        {
            var element = _source.IceCreams.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                _source.IceCreams.Remove(element);
                _source.SaveIceCreams();
                return element.GetViewModel;
            }
            return null;
        }
    }
}