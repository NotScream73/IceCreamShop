using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace IceCreamShopDatabaseImplement.Models
{
    [DataContract]
    public class Additive : IAdditiveModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        [Required]
        public string AdditiveName { get; private set; } = string.Empty;

        [DataMember]
        [Required]
        public double Cost { get; set; }

        [ForeignKey("AdditiveId")]
        public virtual List<IceCreamAdditive> IceCreamAdditives { get; set; } = new();

        public static Additive? Create(AdditiveBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Additive()
            {
                Id = model.Id,
                AdditiveName = model.AdditiveName,
                Cost = model.Cost
            };
        }

        public static Additive Create(AdditiveViewModel model)
        {
            return new Additive
            {
                Id = model.Id,
                AdditiveName = model.AdditiveName,
                Cost = model.Cost
            };
        }

        public void Update(AdditiveBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            AdditiveName = model.AdditiveName;
            Cost = model.Cost;
        }

        public AdditiveViewModel GetViewModel => new()
        {
            Id = Id,
            AdditiveName = AdditiveName,
            Cost = Cost
        };
    }
}
