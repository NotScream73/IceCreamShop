using IceCreamShopContracts.StoragesContracts;

namespace IceCreamShopListImplement.Implements
{
    public class BackUpInfo : IBackUpInfo
    {
        public List<T>? GetList<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public Type? GetTypeByModelInterface(string modelInterfaceName)
        {
            throw new NotImplementedException();
        }
    }
}