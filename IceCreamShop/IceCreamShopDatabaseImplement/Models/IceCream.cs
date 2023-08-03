using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace IceCreamShopDatabaseImplement.Models
{
    [DataContract]
    public class IceCream : IIceCreamModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string IceCreamName { get; set; } = string.Empty;

        [DataMember]
        [Required]
        public double Price { get; set; }

        private Dictionary<int, (IAdditiveModel, int)>? _iceCreamAdditives = null;

        [DataMember]
        [NotMapped]
        public Dictionary<int, (IAdditiveModel, int)> IceCreamAdditives
        {
            get
            {
                if (_iceCreamAdditives == null)
                {
                    _iceCreamAdditives = Additives
                            .ToDictionary(recPC => recPC.AdditiveId, recPC => (recPC.Additive as IAdditiveModel, recPC.Count));
                }
                return _iceCreamAdditives;
            }
        }

        [ForeignKey("IceCreamId")]
        public virtual List<IceCreamAdditive> Additives { get; set; } = new();

        [ForeignKey("IceCreamId")]
        public virtual List<Order> Orders { get; set; } = new();
        [ForeignKey("IceCreamId")]
        public virtual List<ShopIceCream> Shops { get; set; } = new();
        public static IceCream Create(IceCreamShopDatabase context, IceCreamBindingModel model)
        {
            return new IceCream()
            {
                Id = model.Id,
                IceCreamName = model.IceCreamName,
                Price = model.Price,
                Additives = model.IceCreamAdditives.Select(x => new IceCreamAdditive
                {
                    Additive = context.Additives.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
            };
        }

        public void Update(IceCreamBindingModel model)
        {
            IceCreamName = model.IceCreamName;
            Price = model.Price;
        }

        public IceCreamViewModel GetViewModel => new()
        {
            Id = Id,
            IceCreamName = IceCreamName,
            Price = Price,
            IceCreamAdditives = IceCreamAdditives
        };

        public void UpdateAdditives(IceCreamShopDatabase context, IceCreamBindingModel model)
        {
            var iceCreamAdditives = context.IceCreamAdditives.Where(rec => rec.IceCreamId == model.Id).ToList();
            if (iceCreamAdditives != null && iceCreamAdditives.Count > 0)
            {   // удалили те, которых нет в модели
                context.IceCreamAdditives.RemoveRange(iceCreamAdditives.Where(rec => !model.IceCreamAdditives.ContainsKey(rec.AdditiveId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateAdditive in iceCreamAdditives)
                {
                    updateAdditive.Count = model.IceCreamAdditives[updateAdditive.AdditiveId].Item2;
                    model.IceCreamAdditives.Remove(updateAdditive.AdditiveId);
                }
                context.SaveChanges();
            }
            var iceCream = context.IceCreams.First(x => x.Id == Id);
            foreach (var ia in model.IceCreamAdditives)
            {
                context.IceCreamAdditives.Add(new IceCreamAdditive
                {
                    IceCream = iceCream,
                    Additive = context.Additives.First(x => x.Id == ia.Key),
                    Count = ia.Value.Item2
                });
                context.SaveChanges();
            }
            _iceCreamAdditives = null;
        }
    }
}
