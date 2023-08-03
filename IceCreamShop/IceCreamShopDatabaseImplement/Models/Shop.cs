using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCreamShopDatabaseImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; set; }
        [Required]
        public string ShopName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int MaxCountIceCreams { get; set; }
        [Required]
        public DateTime DateOpen { get; set; }
        private Dictionary<int, (IIceCreamModel, int)>? _shopIceCreams = null;
        [NotMapped]
        public Dictionary<int, (IIceCreamModel, int)> ShopIceCreams
        {
            get
            {
                if (_shopIceCreams == null)
                {
                    _shopIceCreams = new();
					IceCreams.ForEach(x =>
                    {
                        if (_shopIceCreams.ContainsKey(x.IceCreamId))
                        {
                            _shopIceCreams[x.IceCreamId] = (x.IceCream as IIceCreamModel, _shopIceCreams[x.IceCreamId].Item2 + x.Count);
                        }
                        else
                        {
							_shopIceCreams[x.IceCreamId] = (x.IceCream as IIceCreamModel, x.Count);
						}
                    });
                }
                return _shopIceCreams;
            }
        }
        [ForeignKey("ShopId")]
        public virtual List<ShopIceCream> IceCreams { get; set; } = new();

        public static Shop Create(IceCreamShopDatabase context, ShopBindingModel model)
        {
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                IceCreams = model.ShopIceCreams.Select(x => new ShopIceCream
                {
                    IceCream = context.IceCreams.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList(),
                MaxCountIceCreams = model.MaxCountIceCreams
            };
        }

        public void Update(ShopBindingModel model)
        {
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            MaxCountIceCreams = model.MaxCountIceCreams;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            MaxCountIceCreams = MaxCountIceCreams,
            ShopIceCreams = ShopIceCreams,
            ShopIceCreamsList = IceCreams.Select(x => new Tuple<IceCreamViewModel,int>(x.IceCream.GetViewModel,x.Count)).ToList()
        };

        public void UpdateIceCreams(IceCreamShopDatabase context, ShopBindingModel model)
        {
            var shopIceCreams = context.ShopIceCreams.Where(rec => rec.ShopId == model.Id).ToList();
            if (shopIceCreams != null && shopIceCreams.Count > 0)
            {   // удалили те, которых нет в модели
                context.ShopIceCreams.RemoveRange(shopIceCreams.Where(rec => !model.ShopIceCreams.ContainsKey(rec.IceCreamId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateIceCream in shopIceCreams)
                {
                    updateIceCream.Count = model.ShopIceCreams[updateIceCream.IceCreamId].Item2;
                    model.ShopIceCreams.Remove(updateIceCream.IceCreamId);
                }
                context.SaveChanges();
            }
            var shop = context.Shops.First(x => x.Id == Id);
            foreach (var si in model.ShopIceCreams)
            {
                context.ShopIceCreams.Add(new ShopIceCream
                {
                    Shop = shop,
                    IceCream = context.IceCreams.First(x => x.Id == si.Key),
                    Count = si.Value.Item2
                });
                context.SaveChanges();
            }
            _shopIceCreams = null;
        }
    }
}
