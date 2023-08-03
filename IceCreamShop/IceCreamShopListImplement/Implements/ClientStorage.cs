using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;

namespace IceCreamShopListImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
		private readonly DataListSingleton _source;

		public ClientStorage()
		{
			_source = DataListSingleton.GetInstance();
		}

		public List<ClientViewModel> GetFullList()
		{
			var result = new List<ClientViewModel>();
			foreach (var client in _source.Clients)
			{
				result.Add(client.GetViewModel);
			}
			return result;
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			var result = new List<ClientViewModel>();

            if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
            {
                return result;
            }
            if (model.Id.HasValue)
            {
                var client = GetElement(model);
                return client == null ? result : new() { client };
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
				foreach (var client in _source.Clients)
				{
					if (client.Email.Contains(model.Email))
					{
						result.Add(client.GetViewModel);
					}
				}
            }
            return result;
		}

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			foreach(var elem in _source.Clients)
			{
				if (model.Id.HasValue && model.Id == elem.Id)
					return elem.GetViewModel;
				if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password) && elem.Email == model.Email && elem.Password == model.Password)
					return elem.GetViewModel;
				if (!string.IsNullOrEmpty(model.Email) && model.Email == elem.Email)
					return elem.GetViewModel;
			}
			return null;
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			model.Id = 1;
			foreach (var client in _source.Clients)
			{
				if (model.Id <= client.Id)
				{
					model.Id = client.Id + 1;
				}
			}
			var newClient = Client.Create(model);
			if (newClient == null)
			{
				return null;
			}
			_source.Clients.Add(newClient);
			return newClient.GetViewModel;
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			foreach (var client in _source.Clients)
			{
				if (client.Id == model.Id)
				{
					client.Update(model);
					return client.GetViewModel;
				}
			}
			return null;
		}

		public ClientViewModel? Delete(ClientBindingModel model)
		{
			for (int i = 0; i < _source.Clients.Count; ++i)
			{
				if (_source.Clients[i].Id == model.Id)
				{
					var element = _source.Clients[i];
					_source.Clients.RemoveAt(i);
					return element.GetViewModel;
				}
			}
			return null;
		}
	}
}