using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IOrderLogic
    {
        List<OrderViewModel>? ReadList(OrderSearchModel? model);
        bool CreateOrder(OrderBindingModel model);
        bool TakeOrderInWork(OrderBindingModel model);
        bool OrderReady(OrderBindingModel model);
        bool IssuedOrder(OrderBindingModel model);
        OrderViewModel? ReadElement(OrderSearchModel orderSearchModel);
    }
}