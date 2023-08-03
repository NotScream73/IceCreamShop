﻿using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopListImplement.Models
{
    public class Client : IClientModel
    {
        public string ClientFIO { get; private set; } = string.Empty;

		public string Email { get; private set; } = string.Empty;

		public string Password { get; private set; } = string.Empty;

		public int Id { get; private set; }
		public static Client? Create(ClientBindingModel? model)
		{
			if (model == null)
			{
				return null;
			}
			return new Client()
			{
				Id = model.Id,
				ClientFIO = model.ClientFIO,
				Email = model.Email,
				Password = model.Password
			};
		}

		public void Update(ClientBindingModel? model)
		{
			if (model == null)
			{
				return;
			}
			ClientFIO = model.ClientFIO;
			Email = model.Email;
			Password = model.Password;
		}

		public ClientViewModel GetViewModel => new()
		{
			Id = Id,
			ClientFIO = ClientFIO,
			Email = Email,
			Password = Password
		};
	}
}