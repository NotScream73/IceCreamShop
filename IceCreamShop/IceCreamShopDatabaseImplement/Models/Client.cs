using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IceCreamShopDatabaseImplement.Models
{
    [DataContract]
    public class Client : IClientModel
    {
        [DataMember]
        [Required]
		public string ClientFIO { get; private set; } = string.Empty;
        [DataMember]
        [Required]
		public string Email { get; private set; } = string.Empty;
        [DataMember]
        [Required]
		public string Password { get; private set; } = string.Empty;
        [DataMember]
        public int Id { get; private set; }

		[ForeignKey("ClientId")]
		public virtual List<Order> Orders { get; set; } = new();

        [ForeignKey("ClientId")]
        public virtual List<MessageInfo> MessageInfos { get; set; } = new();
        public static Client? Create(ClientBindingModel model)
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

		public static Client Create(ClientViewModel model)
		{
			return new Client
			{
				Id = model.Id,
				ClientFIO = model.ClientFIO,
				Email = model.Email,
				Password = model.Password
			};
		}

		public void Update(ClientBindingModel model)
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