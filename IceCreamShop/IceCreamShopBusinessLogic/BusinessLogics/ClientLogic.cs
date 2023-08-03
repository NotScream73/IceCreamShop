using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class ClientLogic : IClientLogic
    {
		private readonly ILogger _logger;
		private readonly IClientStorage _clientStorage;

		public ClientLogic(ILogger<ClientLogic> logger, IClientStorage clientStorage)
		{
			_logger = logger;
			_clientStorage = clientStorage;
		}

		public List<ClientViewModel>? ReadList(ClientSearchModel? model)
		{
			_logger.LogInformation("ReadList. ClientFIO:{ClientFIO}. Id:{Id}", model?.ClientFIO, model?.Id);
			var list = model == null ? _clientStorage.GetFullList() : _clientStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}

		public ClientViewModel? ReadElement(ClientSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. ClientFIO:{ClientFIO}. Id:{Id}", model.ClientFIO, model.Id);
			var element = _clientStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}

		public bool Create(ClientBindingModel model)
		{
			CheckModel(model);
			if (_clientStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public bool Update(ClientBindingModel model)
		{
			CheckModel(model);
			if (_clientStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool Delete(ClientBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_clientStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		private void CheckModel(ClientBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (string.IsNullOrEmpty(model.ClientFIO))
			{
				throw new ArgumentNullException("Нет имени клиента", nameof(model.ClientFIO));
			}
			if(!Regex.IsMatch(model.Email, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Некорректная почта, сынок", nameof(model.Email));
            }
            if (!Regex.IsMatch(model.Password, @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$", RegexOptions.IgnoreCase) || model.Password.Length < 10 || model.Password.Length > 50)
            {
                throw new ArgumentException("Думай лучше. Плохой пароль", nameof(model.Password));
            }
            _logger.LogInformation("Client. ClientFIO:{ClientFIO}. Id: {Id}", model.ClientFIO, model.Id);
			var element = _clientStorage.GetElement(new ClientSearchModel
			{
				Email = model.Email
			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Клиент с такой электронной почтой уже есть");
			}
		}
	}
}
