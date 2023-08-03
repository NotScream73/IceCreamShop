﻿using IceCreamShopContracts.StoragesContracts;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class BackUpInfo : IBackUpInfo
    {
        public List<T>? GetList<T>() where T : class, new()
        {
            using var context = new IceCreamShopDatabase();
            return context.Set<T>().ToList();
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