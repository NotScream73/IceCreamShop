using IceCreamShopContracts.StoragesContracts;

namespace IceCreamShopFileImplement.Implements
{
    public class BackUpInfo : IBackUpInfo
    {
        public List<T>? GetList<T>() where T : class, new()
        {
            var source = DataFileSingleton.GetInstance();
            return (List<T>?)source.GetType().GetProperties().FirstOrDefault(x => x.PropertyType.IsGenericType && x.PropertyType.GetProperty("Item").PropertyType == typeof(T)).GetValue(source);
        }

        public Type? GetTypeByModelInterface(string modelInterfaceName)
        {
            var assembly = typeof(BackUpInfo).Assembly;
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.IsClass && type.GetInterface(modelInterfaceName) != null)
                {
                    return type;
                }
            }
            return null;
        }
    }
}
