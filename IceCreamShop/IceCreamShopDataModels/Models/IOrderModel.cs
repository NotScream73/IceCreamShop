using IceCreamShopDataModels.Enums;

namespace IceCreamShopDataModels.Models
{
    public interface IOrderModel : IId
    {
        int IceCreamId { get; }
        int ClientId { get; }
        int? ImplementerId { get; }
        int Count { get; }
        double Sum { get; }
        OrderStatus Status { get; }
        DateTime DateCreate { get; }
        DateTime? DateImplement { get; }
    }
}