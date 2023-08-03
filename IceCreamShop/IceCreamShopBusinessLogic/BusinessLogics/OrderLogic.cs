using IceCreamShopBusinessLogic.MailWorker;
using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;
using IceCreamShopDataModels.Enums;
using Microsoft.Extensions.Logging;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ILogger _logger;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractMailWorker _abstractMailWorker;
        private readonly IClientStorage _clientStorage;
        private readonly IShopLogic _shopLogic;
        private readonly IIceCreamStorage _iceCreamStorage;
        public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage, IShopLogic shopLogic, IIceCreamStorage iceCreameStorage, AbstractMailWorker abstractMailWorker, IClientStorage clientStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
            _shopLogic = shopLogic;
            _iceCreamStorage = iceCreameStorage;
            _abstractMailWorker = abstractMailWorker;
            _clientStorage = clientStorage;
        }

        public List<OrderViewModel>? ReadList(OrderSearchModel? model)
        {
            _logger.LogInformation("ReadList. OrderId:{Id}", model?.Id);
            var list = model == null ? _orderStorage.GetFullList() : _orderStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        private void CheckModel(OrderBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (model.IceCreamId < 0)
            {
                throw new ArgumentNullException("Нет мороженного с таким ид", nameof(model.IceCreamId));
            }
            if (model.Count <= 0)
            {
                throw new ArgumentNullException("Количество мороженного в заказе должно быть больше 0", nameof(model.Count));
            }
            if (model.Sum <= 0)
            {
                throw new ArgumentException("Сумма заказа должна быть больше 0", nameof(model.Sum));
            }
            _logger.LogInformation("Order. OrderId: {Id}. IceCreamId: {IceCreamId}. Count: {Count} Sum: {Sum}.", model.Id, model.IceCreamId, model.Count, model.Sum);
        }

        public bool CreateOrder(OrderBindingModel model)
        {
            CheckModel(model);
            if (model.Status != OrderStatus.Неизвестен)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            model.Status = OrderStatus.Принят;
            var order = _orderStorage.Insert(model);
            if (order == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            var client = _clientStorage.GetElement(new() { Id = order.ClientId });
            if (client == null)
            {
                _logger.LogWarning("Client not found");
                return false;
            }
            SendMail(client.Email, $"Новый заказ создан. Номер заказа - {order.Id}", $"Заказ №{order.Id} от {order.DateCreate} на сумму {order.Sum:C2} принят.");
            return true;
        }

        public bool ChangeStatus(OrderBindingModel model, OrderStatus newStatus)
        {
            var viewModel = _orderStorage.GetElement(new OrderSearchModel { Id = model.Id });
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (viewModel.Status + 1 != newStatus && viewModel.Status != OrderStatus.Ожидание)
            {
                _logger.LogWarning("Change status operation failed");
                return false;
            }
            if (viewModel.ImplementerId.HasValue)
            {
                model.ImplementerId = viewModel.ImplementerId;
            }
            model.Status = newStatus;
            model.IceCreamId = viewModel.IceCreamId;
            model.Count = viewModel.Count;
            model.Sum = viewModel.Sum;
            model.DateCreate = viewModel.DateCreate;
            if (model.Status == OrderStatus.Готов || viewModel.Status == OrderStatus.Ожидание)
            {
                var iceCream = _iceCreamStorage.GetElement(new() { Id = viewModel.IceCreamId });
                if (iceCream == null)
                {
                    throw new ArgumentNullException(nameof(iceCream));
                }
                if (!_shopLogic.AddIceCreams(iceCream, viewModel.Count))
                {
                    model.Status = OrderStatus.Ожидание;
                    _logger.LogWarning($"AddIceCreams operation failed. Shop is full.");
                }
                else
                {
					model.DateImplement = DateTime.Now;
				}
            }
            else
            {
                model.DateImplement = viewModel.DateImplement;
            }
            CheckModel(model);
            var order = _orderStorage.Update(model);
            if (order == null)
            {
                _logger.LogWarning("Change status operation failed");
                return false;
            }
            var client = _clientStorage.GetElement(new() { Id = order.ClientId });
            if (client == null)
            {
                _logger.LogWarning("Client not found");
                return false;
            }
            SendMail(client.Email, $"Заказ №{order.Id}", $"Заказ №{order.Id} изменил статус на {order.Status}.");
            return true;
        }

        public bool TakeOrderInWork(OrderBindingModel model)
        {
            return ChangeStatus(model, OrderStatus.Выполняется);
        }

        public bool IssuedOrder(OrderBindingModel model)
        {
            return ChangeStatus(model, OrderStatus.Выдан);
        }

        public bool OrderReady(OrderBindingModel model)
        {
            return ChangeStatus(model, OrderStatus.Готов);
        }

        public OrderViewModel? ReadElement(OrderSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. Id:{Id}", model.Id);
            var element = _orderStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public void SendMail(string email, string title, string body)
        {
            _abstractMailWorker.MailSendAsync(new()
            {
                MailAddress = email,
                Subject = title,
                Text = body
            });
        }
    }
}