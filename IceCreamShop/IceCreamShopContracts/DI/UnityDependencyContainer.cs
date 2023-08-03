using Microsoft.Extensions.Logging;
using Unity;
using Unity.Microsoft.Logging;

namespace IceCreamShopContracts.DI
{
    public class UnityDependencyContainer : IDependencyContainer
    {
        private UnityContainer? _unityContrainer;

        public UnityDependencyContainer()
        {
            _unityContrainer = new UnityContainer();
        }

        public void AddLogging(Action<ILoggingBuilder> configure)
        {
            _unityContrainer.AddExtension(new LoggingExtension(LoggerFactory.Create(configure)));
        }

        public void RegisterType<T, U>(bool isSingle) where U : class, T where T : class
        {
            if (isSingle)
            {
                _unityContrainer.RegisterSingleton<T, U>();
            }
            else
            {
                _unityContrainer.RegisterType<T, U>();
            }
        }

        public void RegisterType<T>(bool isSingle) where T : class
        {
            if (isSingle)
            {
                _unityContrainer.RegisterSingleton<T>();
            }
            else
            {
                _unityContrainer.RegisterType<T>();
            }
        }

        public T Resolve<T>()
        {
            return _unityContrainer.Resolve<T>();
        }
    }
}
