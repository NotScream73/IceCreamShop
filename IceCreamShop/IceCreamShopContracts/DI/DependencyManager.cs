using Microsoft.Extensions.Logging;

namespace IceCreamShopContracts.DI
{
    public class DependencyManager
    {
        private readonly IDependencyContainer _dependencyManager;

        private static DependencyManager? _manager;

        private static readonly object _locjObject = new();

        private DependencyManager()
        {
            _dependencyManager = new UnityDependencyContainer();
        }

        public static DependencyManager Instance { get { if (_manager == null) { lock (_locjObject) { _manager = new DependencyManager(); } } return _manager; } }

        /// <summary>
        /// Иницализация библиотек, в которых идут установки зависомстей
        /// </summary>
        public static void InitDependency()
        {
            var ext = ServiceProviderLoader.GetImplementationExtensions();
            if (ext == null)
            {
                throw new ArgumentNullException("Отсутствуют компоненты для загрузки зависимостей по модулям");
            }
            // регистрируем зависимости
            ext.RegisterServices();

            var extBusiness = ServiceProviderLoader.GetBusinessLogicImplementationExtensions();
            if (extBusiness == null)
            {
                throw new ArgumentNullException("Отсутствуют компоненты для загрузки зависимостей по модулям");
            }
            // регистрируем зависимости
            extBusiness.RegisterServices();
        }

        /// <summary>
        /// Регистрация логгера
        /// </summary>
        /// <param name="configure"></param>
        public void AddLogging(Action<ILoggingBuilder> configure) => _dependencyManager.AddLogging(configure);

        /// <summary>
        /// Добавление зависимости
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        public void RegisterType<T, U>(bool isSingle = false) where U : class, T where T : class => _dependencyManager.RegisterType<T, U>(isSingle);

        /// <summary>
        /// Добавление зависимости
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        public void RegisterType<T>(bool isSingle = false) where T : class => _dependencyManager.RegisterType<T>(isSingle);

        /// <summary>
        /// Получение класса со всеми зависмостями
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>() => _dependencyManager.Resolve<T>();
    }
}
