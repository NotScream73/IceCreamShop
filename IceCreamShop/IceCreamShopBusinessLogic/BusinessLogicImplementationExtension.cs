using IceCreamShopBusinessLogic.BusinessLogics;
using IceCreamShopBusinessLogic.MailWorker;
using IceCreamShopBusinessLogic.OfficePackage.Implements;
using IceCreamShopBusinessLogic.OfficePackage;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.DI;

namespace IceCreamShopBusinessLogic
{
    public class BusinessLogicImplementationExtension : IBusinessLogicImplementationExtension
    {
        public int Priority => 0;

        public void RegisterServices()
        {
            DependencyManager.Instance.RegisterType<IAdditiveLogic, AdditiveLogic>();
            DependencyManager.Instance.RegisterType<IOrderLogic, OrderLogic>();
            DependencyManager.Instance.RegisterType<IIceCreamLogic, IceCreamLogic>();
            DependencyManager.Instance.RegisterType<IReportLogic, ReportLogic>();
            DependencyManager.Instance.RegisterType<IClientLogic, ClientLogic>();
            DependencyManager.Instance.RegisterType<IImplementerLogic, ImplementerLogic>();
            DependencyManager.Instance.RegisterType<IMessageInfoLogic, MessageInfoLogic>();
            DependencyManager.Instance.RegisterType<IShopLogic, ShopLogic>();

            DependencyManager.Instance.RegisterType<AbstractSaveToExcel, SaveToExcel>();
            DependencyManager.Instance.RegisterType<AbstractSaveToWord, SaveToWord>();
            DependencyManager.Instance.RegisterType<AbstractSaveToPdf, SaveToPdf>();
            DependencyManager.Instance.RegisterType<IWorkProcess, WorkModeling>();
            DependencyManager.Instance.RegisterType<AbstractMailWorker, MailKitWorker>(true);
            DependencyManager.Instance.RegisterType<IBackUpLogic, BackUpLogic>();
        }
    }
}
