namespace IceCreamShopDataModels.Models
{
    public interface IAdditiveModel : IId
    {
        string AdditiveName { get; }
        double Cost { get; }
    }
}