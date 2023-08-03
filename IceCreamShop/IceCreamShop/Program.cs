using IceCreamShopBusinessLogic.BusinessLogics;
using IceCreamShopBusinessLogic.MailWorker;
using IceCreamShopBusinessLogic.OfficePackage;
using IceCreamShopBusinessLogic.OfficePackage.Implements;
using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.DI;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace IceCreamShopView
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InitDependency();
            try
            {
                var mailSender = DependencyManager.Instance.Resolve<AbstractMailWorker>();
                mailSender?.MailConfig(new MailConfigBindingModel
                {
                    MailLogin = System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ?? string.Empty,
                    MailPassword = System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ?? string.Empty,
                    SmtpClientHost = System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ?? string.Empty,
                    SmtpClientPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
                    PopHost = System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
                    PopPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
                });

                // создаём таймер
                var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
            }
            catch (Exception ex)
            {
                var logger = DependencyManager.Instance.Resolve<ILogger>();
                logger?.LogError(ex, "Ошибка работы с почтой");
            }
            Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }
        private static void InitDependency()
        {
            DependencyManager.InitDependency();

            DependencyManager.Instance.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });

            DependencyManager.Instance.RegisterType<FormAddIceCream>();
            DependencyManager.Instance.RegisterType<FormAdditive>();
            DependencyManager.Instance.RegisterType<FormAdditives>();
            DependencyManager.Instance.RegisterType<FormClients>();
            DependencyManager.Instance.RegisterType<FormCreateOrder>();
            DependencyManager.Instance.RegisterType<FormIceCream>();
            DependencyManager.Instance.RegisterType<FormIceCreamAdditive>();
            DependencyManager.Instance.RegisterType<FormIceCreams>();
            DependencyManager.Instance.RegisterType<FormImplementer>();
            DependencyManager.Instance.RegisterType<FormImplementers>();
            DependencyManager.Instance.RegisterType<FormMain>();
            DependencyManager.Instance.RegisterType<FormMessageAnswer>();
            DependencyManager.Instance.RegisterType<FormMessages>();
            DependencyManager.Instance.RegisterType<FormReportGroupedOrders>();
            DependencyManager.Instance.RegisterType<FormReportIceCreamAdditives>();
            DependencyManager.Instance.RegisterType<FormReportOrders>();
            DependencyManager.Instance.RegisterType<FormReportShopIceCreams>();
            DependencyManager.Instance.RegisterType<FormSellIceCream>();
            DependencyManager.Instance.RegisterType<FormShop>();
            DependencyManager.Instance.RegisterType<FormShops>();
        }

        private static void MailCheck(object obj) => DependencyManager.Instance.Resolve<AbstractMailWorker>()?.MailCheck();
    }
}