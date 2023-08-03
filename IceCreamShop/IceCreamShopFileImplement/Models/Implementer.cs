using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace IceCreamShopFileImplement.Models
{
    [DataContract]
    public class Implementer : IImplementerModel
    {
        [DataMember]
        public string ImplementerFIO { get; private set; } = string.Empty;

        [DataMember]
        public string Password { get; private set; } = string.Empty;

        [DataMember]
        public int WorkExperience { get; private set; }

        [DataMember]
        public int Qualification { get; private set; }

        [DataMember]
        public int Id { get; private set; }

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

        public static Implementer? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Implementer()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ImplementerFIO = element.Element("ImplementerFIO")!.Value,
                Qualification = Convert.ToInt32(element.Element("Qualification")!.Value),
                WorkExperience = Convert.ToInt32(element.Element("WorkExperience")!.Value),
                Password = element.Element("Password")!.Value
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
            WorkExperience = model.WorkExperience;
            Qualification = model.Qualification;
        }

        public ImplementerViewModel GetViewModel => new()
        {
            Id = Id,
            ImplementerFIO = ImplementerFIO,
            Password = Password,
            Qualification = Qualification,
            WorkExperience = WorkExperience
        };

        public XElement GetXElement => new("Implementer", new XAttribute("Id", Id), new XElement("ImplementerFIO", ImplementerFIO), new XElement("Password", Password), new XElement("Qualification", Qualification), new XElement("WorkExperience", WorkExperience));
    }
}