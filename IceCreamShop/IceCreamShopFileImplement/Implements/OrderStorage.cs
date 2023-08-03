using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopFileImplement.Models;

namespace IceCreamShopFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataFileSingleton _source;

        public OrderStorage()
        {
            _source = DataFileSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            return _source.Orders.Select(x => GetViewModel(x)).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (model.ClientId.HasValue)
            {
                return _source.Orders.Where(x => x.ClientId == model.ClientId).Select(x => GetViewModel(x)).ToList();
            }
            if (model.Status.HasValue)
            {
                return _source.Orders.Where(x => x.Status == model.Status).Select(x => GetViewModel(x)).ToList();
            }
            if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                return _source.Orders.Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                              .Select(x => GetViewModel(x))
                              .ToList();
            }
            return _source.Orders.Where(x => x.Id == model.Id).Select(x => GetViewModel(x)).ToList();
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (model.ImplementerId.HasValue && model.Status.HasValue)
            {
                return _source.Orders.FirstOrDefault(x => x.ImplementerId == model.ImplementerId && x.Status == model.Status)?.GetViewModel;
            }
            if (model.ImplementerId.HasValue)
            {
                return _source.Orders.FirstOrDefault(x => x.ImplementerId == model.ImplementerId)?.GetViewModel;
            }
            if (!model.Id.HasValue)
            {
                return null;
            }
            return _source.Orders.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)?.GetViewModel;
        }

        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            var iceCream = _source.IceCreams.FirstOrDefault(x => x.Id == order.IceCreamId);
            if (iceCream != null)
            {
                viewModel.IceCreamName = iceCream.IceCreamName;
            }
            foreach (var client in _source.Clients)
            {
                if (client.Id == order.ClientId)
                {
                    viewModel.ClientFIO = client.ClientFIO;
                    break;
                }
            }
            return viewModel;
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = _source.Orders.Count > 0 ? _source.Orders.Max(x => x.Id) + 1 : 1;
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            _source.Orders.Add(newOrder);
            _source.SaveOrders();
            return GetViewModel(newOrder);
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            var order = _source.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            _source.SaveOrders();
            return GetViewModel(order);
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            var order = _source.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order != null)
            {
                _source.Orders.Remove(order);
                _source.SaveOrders();
                return GetViewModel(order);
            }
            return null;
        }
    }
}