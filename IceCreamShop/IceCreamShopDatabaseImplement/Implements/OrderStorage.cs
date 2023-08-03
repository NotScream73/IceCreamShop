using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var element = context.Orders
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                // для отображения КОРРЕКТНОЙ viewmodelи
                var deletedElement = context.Orders
                                            .Include(x => x.IceCream)
                                            .Include(x => x.Client)
                                            .Include(x => x.Implementer)
                                            .FirstOrDefault(x => x.Id == model.Id)
                                            ?.GetViewModel;
                context.Orders.Remove(element);
                context.SaveChanges();
                return deletedElement;
            }
            return null;
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            using var context = new IceCreamShopDatabase();
            if (model.ImplementerId.HasValue && model.Status.HasValue)
            {
                return context.Orders
                              .Include(x => x.IceCream)
                              .Include(x => x.Client)
                              .Include(x => x.Implementer)
                              .FirstOrDefault(x => x.ImplementerId == model.ImplementerId && x.Status == model.Status)
                              ?.GetViewModel;
            }
            if (model.ImplementerId.HasValue)
            {
                return context.Orders
                              .Include(x => x.IceCream)
                              .Include(x => x.Client)
                              .Include(x => x.Implementer)
                              .FirstOrDefault(x => x.ImplementerId == model.ImplementerId)
                              ?.GetViewModel;
            }
            if (!model.Id.HasValue)
            {
                return null;
            }
            return context.Orders
                .Include(x => x.IceCream)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
                .FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
                ?.GetViewModel;
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            
            using var context = new IceCreamShopDatabase();
            if (model.ClientId.HasValue)
            {
                return context.Orders.Include(x => x.IceCream)
                                     .Include(x => x.Client)
                                     .Include(x => x.Implementer)
                                     .Where(x => x.ClientId == model.ClientId)
                                     .Select(x => x.GetViewModel)
                                     .ToList();
            }
            if (model.Status.HasValue)
            {
                return context.Orders
                              .Include(x => x.IceCream)
                              .Include(x => x.Client)
                              .Include(x => x.Implementer)
                              .Where(x => x.Status == model.Status)
                              .Select(x => x.GetViewModel)
                              .ToList();
            }
            if (!model.Id.HasValue && !model.DateFrom.HasValue && !model.DateTo.HasValue)
                return new();
            if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                return context.Orders
                              .Include(x => x.IceCream)
                              .Include(x => x.Client)
                              .Include(x => x.Implementer)
                              .Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                              .Select(x => x.GetViewModel)
                              .ToList();
            }
            return context.Orders
                    .Include(x => x.IceCream)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.Id == model.Id)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }
        
        public List<OrderViewModel> GetFullList()
        {
            using var context = new IceCreamShopDatabase();
            return context.Orders
                    .Include(x => x.IceCream)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            context.Orders.Add(newOrder);
            context.SaveChanges();
            return context.Orders
                          .Include(x => x.IceCream)
                          .Include(x => x.Client)
                          .Include(x => x.Implementer)
                          .FirstOrDefault(x => x.Id == newOrder.Id)
                          ?.GetViewModel;
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var order = context.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return context.Orders
                          .Include(x => x.IceCream)
                          .Include(x => x.Client)
                          .Include(x => x.Implementer)
                          .FirstOrDefault(x => x.Id == model.Id)
                          ?.GetViewModel;
        }
    }
}
