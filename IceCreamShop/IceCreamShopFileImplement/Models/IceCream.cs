using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace IceCreamShopFileImplement.Models
{
    [DataContract]
    public class IceCream : IIceCreamModel
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string IceCreamName { get; private set; } = string.Empty;
        [DataMember]
        public double Price { get; private set; }
        public Dictionary<int, int> Additives { get; private set; } = new();
        private Dictionary<int, (IAdditiveModel, int)>? _iceCreamAdditives = null;

        [DataMember]
        public Dictionary<int, (IAdditiveModel, int)> IceCreamAdditives
        {
            get
            {
                if (_iceCreamAdditives == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _iceCreamAdditives = Additives.ToDictionary(x => x.Key, y => ((source.Additives.FirstOrDefault(z => z.Id == y.Key) as IAdditiveModel)!, y.Value));
                }
                return _iceCreamAdditives;
            }
        }

        public static IceCream? Create(IceCreamBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new IceCream()
            {
                Id = model.Id,
                IceCreamName = model.IceCreamName,
                Price = model.Price,
                Additives = model.IceCreamAdditives.ToDictionary(x => x.Key, x => x.Value.Item2)
            };
        }

        public static IceCream? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new IceCream()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                IceCreamName = element.Element("IceCreamName")!.Value,
                Price = Convert.ToDouble(element.Element("Price")!.Value),
                Additives = element.Element("IceCreamAdditives")!.Elements("IceCreamAdditive").ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value), x => Convert.ToInt32(x.Element("Value")?.Value))
            };
        }

        public void Update(IceCreamBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            IceCreamName = model.IceCreamName;
            Price = model.Price;
            Additives = model.IceCreamAdditives.ToDictionary(x => x.Key, x => x.Value.Item2);
            _iceCreamAdditives = null;
        }
        public IceCreamViewModel GetViewModel => new()
        {
            Id = Id,
            IceCreamName = IceCreamName,
            Price = Price,
            IceCreamAdditives = IceCreamAdditives
        };
        public XElement GetXElement => new("IceCream", new XAttribute("Id", Id), new XElement("IceCreamName", IceCreamName), new XElement("Price", Price.ToString()), new XElement("IceCreamAdditives", Additives.Select(x => new XElement("IceCreamAdditive", new XElement("Key", x.Key), new XElement("Value", x.Value))).ToArray()));
    }
}