using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class AdditiveStorage : IAdditiveStorage
    {
        public List<AdditiveViewModel> GetFullList()
        {
            using var context = new IceCreamShopDatabase();
            return context.Additives
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<AdditiveViewModel> GetFilteredList(AdditiveSearchModel model)
        {
            if (string.IsNullOrEmpty(model.AdditiveName))
            {
                return new();
            }
            using var context = new IceCreamShopDatabase();
            return context.Additives
                    .Where(x => x.AdditiveName.Contains(model.AdditiveName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public AdditiveViewModel? GetElement(AdditiveSearchModel model)
        {
            if (string.IsNullOrEmpty(model.AdditiveName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            return context.Additives
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.AdditiveName) && x.AdditiveName == model.AdditiveName) ||
                                        (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public AdditiveViewModel? Insert(AdditiveBindingModel model)
        {
            var newAdditive = Additive.Create(model);
            if (newAdditive == null)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            context.Additives.Add(newAdditive);
            context.SaveChanges();
            return newAdditive.GetViewModel;
        }

        public AdditiveViewModel? Update(AdditiveBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var additive = context.Additives.FirstOrDefault(x => x.Id == model.Id);
            if (additive == null)
            {
                return null;
            }
            additive.Update(model);
            context.SaveChanges();
            return additive.GetViewModel;
        }

        public AdditiveViewModel? Delete(AdditiveBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var element = context.Additives.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Additives.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
