using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace IceCreamShopFileImplement.Models
{
    [DataContract]
    public class Additive : IAdditiveModel
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string AdditiveName { get; private set; } = string.Empty;
        [DataMember]
        public double Cost { get; set; }

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

        public static Additive? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Additive()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                AdditiveName = element.Element("AdditiveName")!.Value,
                Cost = Convert.ToDouble(element.Element("Cost")!.Value)
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

        public XElement GetXElement => new("Additive",new XAttribute("Id", Id), new XElement("AdditiveName", AdditiveName), new XElement("Cost", Cost.ToString()));
    }
}