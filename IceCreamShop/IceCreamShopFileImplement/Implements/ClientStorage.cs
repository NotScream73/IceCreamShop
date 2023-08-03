using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopFileImplement.Models;

namespace IceCreamShopFileImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
		private readonly DataFileSingleton _source;

		public ClientStorage()
		{
			_source = DataFileSingleton.GetInstance();
		}

		public List<ClientViewModel> GetFullList()
		{
			return _source.Clients.Select(x => x.GetViewModel).ToList();
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
                return client == null ? new() : new() { client };
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                return _source.Clients
                        .Where(x => x.Email.Contains(model.Email))
                        .Select(x => x.GetViewModel)
                        .ToList();
            }
            return new();
        }

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
            if (model.Id.HasValue)
                return _source.Clients
                              .FirstOrDefault(x => x.Id == model.Id)
                              ?.GetViewModel;
            if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
                return _source.Clients
                              .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password)
                              ?.GetViewModel;
            if (!string.IsNullOrEmpty(model.Email))
                return _source.Clients
                              .FirstOrDefault(x => x.Email == model.Email)
                              ?.GetViewModel;
            return null;
        }

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			model.Id = _source.Clients.Count > 0 ? _source.Clients.Max(x => x.Id) + 1 : 1;
			var newClient = Client.Create(model);
			if (newClient == null)
			{
				return null;
			}
			_source.Clients.Add(newClient);
			_source.SaveClients();
			return newClient.GetViewModel;
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			var client = _source.Clients.FirstOrDefault(x => x.Id == model.Id);
			if (client == null)
			{
				return null;
			}
			client.Update(model);
			_source.SaveClients();
			return client.GetViewModel;
		}

		public ClientViewModel? Delete(ClientBindingModel model)
		{
			var element = _source.Clients.FirstOrDefault(x => x.Id == model.Id);
			if (element != null)
			{
				_source.Clients.Remove(element);
				_source.SaveClients();
				return element.GetViewModel;
			}
			return null;
		}
	}
}