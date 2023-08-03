using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.Xml.Linq;

namespace IceCreamShopFileImplement.Models
{
    public class Shop : IShopModel
    {
        public string ShopName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DateOpen { get; set; }
        public int Id { get; set; }

        public int MaxCountIceCreams { get; set; }
        public Dictionary<int, int> IceCreams { get; private set; } = new();
        private Dictionary<int, (IIceCreamModel, int)>? _shopIceCreams = null;

        public Dictionary<int, (IIceCreamModel, int)> ShopIceCreams
        {
            get
            {
                if (_shopIceCreams == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _shopIceCreams = IceCreams.ToDictionary(x => x.Key, y => ((source.IceCreams.FirstOrDefault(z => z.Id == y.Key) as IIceCreamModel)!, y.Value));
                }
                return _shopIceCreams;
            }
        }
        public static Shop? Create(ShopBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpen = model.DateOpen,
                MaxCountIceCreams = model.MaxCountIceCreams,
                IceCreams = model.ShopIceCreams.ToDictionary(x => x.Key, x => x.Value.Item2)
            };
        }
        public static Shop? Create(XElement element)

        {
            if (element == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ShopName = element.Element("ShopName")!.Value,
                Address = element.Element("Address")!.Value,
                DateOpen = Convert.ToDateTime(element.Element("DateOpen")!.Value),
                MaxCountIceCreams = Convert.ToInt32(element.Element("MaxCountIceCreams")!.Value),
                IceCreams = element.Element("IceCreams")!.Elements("IceCreams").ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value), x => Convert.ToInt32(x.Element("Value")?.Value))
            };
        }
        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpen = model.DateOpen;
            MaxCountIceCreams = model.MaxCountIceCreams;
            IceCreams = model.ShopIceCreams.ToDictionary(x => x.Key, x => x.Value.Item2);
            _shopIceCreams = null;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpen = DateOpen,
            MaxCountIceCreams = MaxCountIceCreams,
            ShopIceCreams = ShopIceCreams
        };
        public XElement GetXElement => new("Shop",
            new XAttribute("Id", Id),
            new XElement("ShopName", ShopName),
            new XElement("Address", Address),
            new XElement("DateOpen", DateOpen.ToString()),
            new XElement("MaxCountIceCreams", MaxCountIceCreams.ToString()),
            new XElement("IceCreams", IceCreams.Select(x => new XElement("IceCreams",
                new XElement("Key", x.Key),
                new XElement("Value", x.Value))).ToArray()));
    }
}