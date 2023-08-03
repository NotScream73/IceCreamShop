using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Models;

namespace IceCreamShopListImplement.Models
{
    public class Implementer : IImplementerModel
    {
        public string ImplementerFIO { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public int WorkExperience { get; private set; }

        public int Qualification { get; private set; }

        public int Id { get; private set; }
        public static Implementer? Create(ImplementerBindingModel? model)
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

        public void Update(ImplementerBindingModel? model)
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
    }
}