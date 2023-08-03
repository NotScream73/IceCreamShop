using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;

namespace IceCreamShopListImplement.Implements
{
    public class IceCreamStorage : IIceCreamStorage
    {
        private readonly DataListSingleton _source;

        public IceCreamStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public List<IceCreamViewModel> GetFullList()
        {
            var result = new List<IceCreamViewModel>();
            foreach (var iceCream in _source.IceCreams)
            {
                result.Add(iceCream.GetViewModel);
            }
            return result;
        }

        public List<IceCreamViewModel> GetFilteredList(IceCreamSearchModel model)
        {
            var result = new List<IceCreamViewModel>();
            if (string.IsNullOrEmpty(model.IceCreamName))
            {
                return result;
            }
            foreach (var iceCream in _source.IceCreams)
            {
                if (iceCream.IceCreamName.Contains(model.IceCreamName))
                {
                    result.Add(iceCream.GetViewModel);
                }
            }
            return result;
        }

        public IceCreamViewModel? GetElement(IceCreamSearchModel model)
        {
            if (string.IsNullOrEmpty(model.IceCreamName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var iceCream in _source.IceCreams)
            {
                if ((!string.IsNullOrEmpty(model.IceCreamName) && iceCream.IceCreamName == model.IceCreamName) || (model.Id.HasValue && iceCream.Id == model.Id))
                {
                    return iceCream.GetViewModel;
                }
            }
            return null;
        }

        public IceCreamViewModel? Insert(IceCreamBindingModel model)
        {
            model.Id = 1;
            foreach (var iceCream in _source.IceCreams)
            {
                if (model.Id <= iceCream.Id)
                {
                    model.Id = iceCream.Id + 1;
                }
            }
            var newIceCream = IceCream.Create(model);
            if (newIceCream == null)
            {
                return null;
            }
            _source.IceCreams.Add(newIceCream);
            return newIceCream.GetViewModel;
        }

        public IceCreamViewModel? Update(IceCreamBindingModel model)
        {
            foreach (var iceCream in _source.IceCreams)
            {
                if (iceCream.Id == model.Id)
                {
                    iceCream.Update(model);
                    return iceCream.GetViewModel;
                }
            }
            return null;
        }

        public IceCreamViewModel? Delete(IceCreamBindingModel model)
        {
            for (int i = 0; i < _source.IceCreams.Count; ++i)
            {
                if (_source.IceCreams[i].Id == model.Id)
                {
                    var element = _source.IceCreams[i];
                    _source.IceCreams.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}