namespace IceCreamShopDataModels.Models
{
    public interface IShopModel : IId
    {
        string ShopName { get; }
        string Address { get; }
        DateTime DateOpen { get; }
        int MaxCountIceCreams { get; }
        Dictionary<int, (IIceCreamModel iceCream, int count)> ShopIceCreams { get; }
    }
}