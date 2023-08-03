namespace IceCreamShopDataModels.Models
{
    public interface IIceCreamModel : IId
    {
        string IceCreamName { get; }
        double Price { get; }
        Dictionary<int, (IAdditiveModel, int)> IceCreamAdditives { get; }
    }
}