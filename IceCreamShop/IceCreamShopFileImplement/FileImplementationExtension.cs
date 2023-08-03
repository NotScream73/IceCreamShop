using IceCreamShopContracts.DI;
using IceCreamShopContracts.StoragesContracts;
using IceCreamShopFileImplement.Implements;

namespace IceCreamShopFileImplement
{
    public class FileImplementationExtension : IImplementationExtension
    {
        public int Priority => 1;

        public void RegisterServices()
        {
            DependencyManager.Instance.RegisterType<IClientStorage, ClientStorage>();
            DependencyManager.Instance.RegisterType<IAdditiveStorage, AdditiveStorage>();
            DependencyManager.Instance.RegisterType<IImplementerStorage, ImplementerStorage>();
            DependencyManager.Instance.RegisterType<IMessageInfoStorage, MessageInfoStorage>();
            DependencyManager.Instance.RegisterType<IOrderStorage, OrderStorage>();
            DependencyManager.Instance.RegisterType<IIceCreamStorage, IceCreamStorage>();
            DependencyManager.Instance.RegisterType<IBackUpInfo, BackUpInfo>();
            DependencyManager.Instance.RegisterType<IShopStorage, ShopStorage>();
        }
    }
}
