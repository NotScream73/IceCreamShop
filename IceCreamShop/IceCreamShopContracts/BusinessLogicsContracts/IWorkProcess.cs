namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IWorkProcess
    {
        /// <summary>
        /// Запуск работ
        /// </summary>
        void DoWork(IImplementerLogic implementerLogic, IOrderLogic orderLogic);
    }
}