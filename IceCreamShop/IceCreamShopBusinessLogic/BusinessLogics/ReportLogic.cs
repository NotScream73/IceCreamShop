using IceCreamShopBusinessLogic.OfficePackage;
using IceCreamShopBusinessLogic.OfficePackage.HelperModels;
using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.SearchModels;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IIceCreamStorage _iceCreamStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly IShopStorage _shopStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IIceCreamStorage iceCreamStorage, IOrderStorage orderStorage, IShopStorage shopStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _iceCreamStorage = iceCreamStorage;
            _orderStorage = orderStorage;
            _shopStorage = shopStorage;

            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        /// <summary>
        /// Получение списка добавок с указанием, в каких мороженых используются
        /// </summary>
        /// <returns></returns>
        public List<ReportIceCreamAdditiveViewModel> GetIceCreamAdditive()
        {
            var iceCreams = _iceCreamStorage.GetFullList();

            var list = new List<ReportIceCreamAdditiveViewModel>();

            foreach (var iceCream in iceCreams)
            {
                var record = new ReportIceCreamAdditiveViewModel
                {
                    IceCreamName = iceCream.IceCreamName,
                    Additives = new List<(string, int)>(),
                    TotalCount = 0
                };
                foreach (var additive in iceCream.IceCreamAdditives)
                {
                    record.Additives.Add(new(additive.Value.Item1.AdditiveName, additive.Value.Item2));
                    record.TotalCount += additive.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        /// <summary>
        /// Получение списка мороженых с указанием, в каких магазинах в наличии
        /// </summary>
        /// <returns></returns>
        public List<ReportShopIceCreamsViewModel> GetShopIceCreams()
        {
            var shops = _shopStorage.GetFullList();

            var list = new List<ReportShopIceCreamsViewModel>();

            foreach (var shop in shops)
            {
                var record = new ReportShopIceCreamsViewModel
                {
                    ShopName = shop.ShopName,
                    IceCreams = new List<(string, int)>(),
                    TotalCount = 0
                };
                foreach (var iceCream in shop.ShopIceCreams)
                {
                    record.IceCreams.Add(new(iceCream.Value.Item1.IceCreamName, iceCream.Value.Item2));
                    record.TotalCount += iceCream.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderSearchModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
                    .Select(x => new ReportOrdersViewModel
                    {
                        Id = x.Id,
                        DateCreate = x.DateCreate,
                        IceCreamName = x.IceCreamName,
                        Sum = x.Sum,
                        OrderStatus = x.Status.ToString()
                    })
                    .ToList();
        }

        /// <summary>
        /// Получение списка заказов за весь период
        /// </summary>
        /// <returns></returns>
        public List<ReportGroupedOrdersViewModel> GetGroupedOrders()
        {
            return _orderStorage.GetFullList()
                    .GroupBy(x => x.DateCreate.Date)
                    .Select(x => new ReportGroupedOrdersViewModel
                    {
                        DateCreate = x.Key,
                        Count = x.Count(),
                        Sum = x.Sum(x => x.Sum)
                    })
                    .ToList();
        }
        /// <summary>
        /// Сохранение мороженых в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveIceCreamsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список мороженых",
                IceCreams = _iceCreamStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение мороженых в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveShopsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateTable(new WordInfo
            {
                FileName = model.FileName,
                Title = "Таблица магазинов",
                Shops = _shopStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение добавок с указаеним мороженых в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveIceCreamAdditiveToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список добавок",
                IceCreamAdditives = GetIceCreamAdditive()
            });
        }

        /// <summary>
        /// Сохранение магазинов с указанием мороженых в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveShopIceCreamsToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateShopReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список магазинов",
                ShopIceCreams = GetShopIceCreams()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom!.Value,
                DateTo = model.DateTo!.Value,
                Orders = GetOrders(model)
            });
        }

        /// <summary>
        /// Сохранение заказов за весь период в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveGroupedOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateGroupedDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                GroupedOrders = GetGroupedOrders()
            });
        }
    }
}
