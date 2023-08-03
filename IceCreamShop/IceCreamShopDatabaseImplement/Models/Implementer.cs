using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace IceCreamShopDatabaseImplement.Models
{
    [DataContract]
    public class Implementer : IImplementerModel
    {
        [DataMember]
        [Required]
        public string ImplementerFIO { get; private set; } = string.Empty;
        [DataMember]
        [Required]
        public string Password { get; private set; } = string.Empty;
        [DataMember]
        [Required]
        public int WorkExperience { get; private set; }
        [DataMember]
        [Required]
        public int Qualification { get; private set; }
        [DataMember]
        [Required]
        public int Id { get; private set; }
        [ForeignKey("ImplementerId")]
        public virtual List<Order> Orders { get; set; } = new();
        public static Implementer? Create(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Implementer()
            {
                Id = model.Id,
                ImplementerFIO = model.ImplementerFIO,
                Qualification = model.Qualification,
                WorkExperience = model.WorkExperience,
                Password = model.Password
            };
        }

        public static Implementer Create(ImplementerViewModel model)
        {
            return new Implementer
            {
                Id = model.Id,
                ImplementerFIO = model.ImplementerFIO,
                Qualification = model.Qualification,
                WorkExperience = model.WorkExperience,
                Password = model.Password
            };
        }

        public void Update(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ImplementerFIO = model.ImplementerFIO;
            Password = model.Password;
            Qualification = model.Qualification;
            WorkExperience = model.WorkExperience;
        }

        public ImplementerViewModel GetViewModel => new()
        {
            Id = Id,
            ImplementerFIO = ImplementerFIO,
            Qualification = Qualification,
            WorkExperience = WorkExperience,
            Password = Password
        };
    }
}