using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// <summary>
        /// Получение списка добавок с указанием, в каких мороженых используются
        /// </summary>
        /// <returns></returns>
        List<ReportIceCreamAdditiveViewModel> GetIceCreamAdditive();
        /// <summary>
        /// Получение списка мороженых с указанием, в каких магазинах в наличии
        /// </summary>
        /// <returns></returns>
        List<ReportShopIceCreamsViewModel> GetShopIceCreams();
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        /// <summary>
        /// Получение списка заказов за весь период
        /// </summary>
        /// <returns></returns>
        List<ReportGroupedOrdersViewModel> GetGroupedOrders();
        /// <summary>
        /// Сохранение добавок в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveIceCreamsToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение магазинов в виде таблицы в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveShopsToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение добавок с указаеним мороженых в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveIceCreamAdditiveToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение магазинов с указанием мороженых в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveShopIceCreamsToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов за весь период в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveGroupedOrdersToPdfFile(ReportBindingModel model);
    }
}
