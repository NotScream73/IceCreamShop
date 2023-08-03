using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;
using IceCreamShopDataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class ShopStorage : IShopStorage
    {
        public List<ShopViewModel> GetFullList()
        {
            using var context = new IceCreamShopDatabase();
            return context.Shops
                    .Include(x => x.IceCreams)
                    .ThenInclude(x => x.IceCream)
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            using var context = new IceCreamShopDatabase();
            return context.Shops
                    .Include(x => x.IceCreams)
                    .ThenInclude(x => x.IceCream)
                    .Where(x => x.ShopName.Contains(model.ShopName))
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new IceCreamShopDatabase();
            return context.Shops
                .Include(x => x.IceCreams)
                .ThenInclude(x => x.IceCream)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) ||
                                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var newShop = Shop.Create(context, model);
            if (newShop == null)
            {
                return null;
            }
            context.Shops.Add(newShop);
            context.SaveChanges();
            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var shop = context.Shops.FirstOrDefault(rec => rec.Id == model.Id);
                if (shop == null)
                {
                    return null;
                }
                shop.Update(model);
                context.SaveChanges();
                if(model.ShopIceCreams.Count > 0)
				{
					shop.UpdateIceCreams(context, model);
				}
                transaction.Commit();
                return shop.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public ShopViewModel? Delete(ShopBindingModel model)
        {
            using var context = new IceCreamShopDatabase();
            var element = context.Shops
                .Include(x => x.IceCreams)
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Shops.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public bool SellIceCreams(IIceCreamModel model, int count)
        {
            using var context = new IceCreamShopDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var shops = context.ShopIceCreams
                                   .Include(x => x.Shop)
                                   .ToList()
                                   .Where(rec => rec.IceCreamId == model.Id);
                if (shops == null)
                {
                    return false;
                }
                foreach(var shop in shops)
                {
                    if (shop.Count < count)
                    {
                        count -= shop.Count;
                        shop.Count = 0;
                    }
                    else
                    {
                        shop.Count = shop.Count - count;
                        count -= count;
                    }
                    if (count == 0)
                    {

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                }
                transaction.Rollback();
                return false;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
