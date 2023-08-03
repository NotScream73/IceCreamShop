using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class IceCreamStorage : IIceCreamStorage
    {
		public List<IceCreamViewModel> GetFullList()
		{
			using var context = new IceCreamShopDatabase();
			return context.IceCreams
					.Include(x => x.Additives)
					.ThenInclude(x => x.Additive)
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<IceCreamViewModel> GetFilteredList(IceCreamSearchModel model)
		{
			if (string.IsNullOrEmpty(model.IceCreamName))
			{
				return new();
			}
			using var context = new IceCreamShopDatabase();
			return context.IceCreams
					.Include(x => x.Additives)
					.ThenInclude(x => x.Additive)
					.Where(x => x.IceCreamName.Contains(model.IceCreamName))
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public IceCreamViewModel? GetElement(IceCreamSearchModel model)
		{
			if (string.IsNullOrEmpty(model.IceCreamName) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new IceCreamShopDatabase();
			return context.IceCreams
				.Include(x => x.Additives)
				.ThenInclude(x => x.Additive)
				.FirstOrDefault(x => (!string.IsNullOrEmpty(model.IceCreamName) && x.IceCreamName == model.IceCreamName) ||
								(model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public IceCreamViewModel? Insert(IceCreamBindingModel model)
		{
			using var context = new IceCreamShopDatabase();
			var newIceCream = IceCream.Create(context, model);
			if (newIceCream == null)
			{
				return null;
			}
			context.IceCreams.Add(newIceCream);
			context.SaveChanges();
			return newIceCream.GetViewModel;
		}

		public IceCreamViewModel? Update(IceCreamBindingModel model)
		{
			using var context = new IceCreamShopDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var iceCream = context.IceCreams.FirstOrDefault(rec => rec.Id == model.Id);
				if (iceCream == null)
				{
					return null;
				}
				iceCream.Update(model);
				context.SaveChanges();
				iceCream.UpdateAdditives(context, model);
				transaction.Commit();
				return iceCream.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public IceCreamViewModel? Delete(IceCreamBindingModel model)
		{
			using var context = new IceCreamShopDatabase();
			var element = context.IceCreams
				.Include(x => x.Additives)
				.Include(x => x.Orders)
				.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.IceCreams.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
