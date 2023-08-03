using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        public List<ImplementerViewModel> GetFullList()
        {
            using var context = new IceCreamShopDatabase();
            return context.Implementers
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ImplementerFIO) && !model.Id.HasValue)
            {
                return new();
            }
            if (model.Id.HasValue)
            {
                var Implementer = GetElement(model);
                return Implementer == null ? new() : new() { Implementer };
            }
            if (!string.IsNullOrEmpty(model.ImplementerFIO))
            {
                using var context = new IceCreamShopDatabase();
                return context.Implementers
                        .Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO))
                        .Select(x => x.GetViewModel)
                        .ToList();
            }
            return new();
        }

        public ImplementerViewModel? GetElement(ImplementerSearchModel model)
        {
            using var context = new IceCreamShopDatabase();
            if (model.Id.HasValue)
                return context.Implementers
                              .FirstOrDefault(x => x.Id == model.Id)
                              ?.GetViewModel;
            if (!string.IsNullOrEmpty(model.ImplementerFIO) && !string.IsNullOrEmpty(model.Password))
                return context.Implementers
                              .FirstOrDefault(x => x.ImplementerFIO == model.ImplementerFIO && x.Password == model.Password)
                              ?.GetViewModel;
            if (!string.IsNullOrEmpty(model.ImplementerFIO))
                return context.Implementers
                              .FirstOrDefault(x => x.ImplementerFIO == model.ImplementerFIO)
                              ?.GetViewModel;
            return null;
        }

        public ImplementerViewModel? Insert(ImplementerBindingModel model)
        {
            var newImplementer = Implementer.Create(model);
            if (newImplementer == null)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            context.Implementers.Add(newImplementer);
            context.SaveChanges();
            return newImplementer.GetViewModel;
        }

        public ImplementerViewModel? Update(ImplementerBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var additive = context.Implementers.FirstOrDefault(x => x.Id == model.Id);
            if (additive == null)
            {
                return null;
            }
            additive.Update(model);
            context.SaveChanges();
            return additive.GetViewModel;
        }

        public ImplementerViewModel? Delete(ImplementerBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Implementers.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}