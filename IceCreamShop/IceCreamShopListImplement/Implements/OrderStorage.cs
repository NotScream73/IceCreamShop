using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopListImplement.Models;

namespace IceCreamShopListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton _source;

        public OrderStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var order in _source.Orders)
            {
                result.Add(GetViewModel(order));
            }
            return result;
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
			var result = new List<OrderViewModel>();
            if (model.ClientId.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.ClientId == model.ClientId)
                    {
                        result.Add(GetViewModel(order));
                    }
                }
                return result;
			}
			if (model.Status.HasValue)
			{
				foreach (var order in _source.Orders)
				{
					if (order.Status == model.Status)
					{
						result.Add(GetViewModel(order));
					}
				}
                return result;
			}
			if (!model.Id.HasValue && model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                foreach(var order in _source.Orders)
                {
                    if (order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                    {
                        result.Add(GetViewModel(order));
                    }
                }
                return result;
            }
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    result.Add(GetViewModel(order));
                }
            }
            return result;
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (model.ImplementerId.HasValue && model.Status.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.ImplementerId == model.ImplementerId && order.Status == model.Status)
                    {
                        return GetViewModel(order);
                    }
                }
            }
            if (model.ImplementerId.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.ImplementerId == model.ImplementerId)
                    {
                        return GetViewModel(order);
                    }
                }
            }
            if (!model.Id.HasValue)
			{
				return null;
			}
			foreach (var order in _source.Orders)
			{
				if (order.Id == model.Id)
				{
					return GetViewModel(order);
				}
			}
			return null;
        }

        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            foreach (var iceCream in _source.IceCreams)
            {
                if (iceCream.Id == order.IceCreamId)
                {
                    viewModel.IceCreamName = iceCream.IceCreamName;
                    break;
                }
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
            model.Id = 1;
            foreach (var order in _source.Orders)
            {
                if (model.Id <= order.Id)
                {
                    model.Id = order.Id + 1;
                }
            }
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            _source.Orders.Add(newOrder);
            return GetViewModel(newOrder);
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    order.Update(model);
                    return GetViewModel(order);
                }
            }
            return null;
        }

        public OrderViewModel? Delete(OrderBindingModel model)
        {
            for (int i = 0; i < _source.Orders.Count; ++i)
            {
                if (_source.Orders[i].Id == model.Id)
                {
                    var element = _source.Orders[i];
                    _source.Orders.RemoveAt(i);
                    return GetViewModel(element);
                }
            }
            return null;
        }
    }
}