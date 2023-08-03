using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDatabaseImplement.Models;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
		public List<ClientViewModel> GetFullList()
		{
			using var context = new IceCreamShopDatabase();
			return context.Clients
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
			{
				return new();
			}
			if (model.Id.HasValue)
			{
				var client = GetElement(model);
				return client == null ? new() : new(){ client };
			}
			if (!string.IsNullOrEmpty(model.Email))
			{
                using var context = new IceCreamShopDatabase();
                return context.Clients
                        .Where(x => x.Email.Contains(model.Email))
                        .Select(x => x.GetViewModel)
                        .ToList();
            }
			return new();
		}

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			using var context = new IceCreamShopDatabase();
			if (model.Id.HasValue)
				return context.Clients
							  .FirstOrDefault(x => x.Id == model.Id)
							  ?.GetViewModel;
			if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
				return context.Clients
							  .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password)
							  ?.GetViewModel;
			if (!string.IsNullOrEmpty(model.Email))
				return context.Clients
							  .FirstOrDefault(x => x.Email == model.Email)
							  ?.GetViewModel;
			return null;
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			var newClient = Client.Create(model);
			if (newClient == null)
			{
				return null;
			}
			using var context = new IceCreamShopDatabase();
			context.Clients.Add(newClient);
			context.SaveChanges();
			return newClient.GetViewModel;
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			using var context = new IceCreamShopDatabase();
			var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
			if (client == null)
			{
				return null;
			}
			client.Update(model);
			context.SaveChanges();
			return client.GetViewModel;
		}

		public ClientViewModel? Delete(ClientBindingModel model)
		{
			using var context = new IceCreamShopDatabase();
			var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Clients.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
