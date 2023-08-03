using IceCreamShopListImplement.Models;

namespace IceCreamShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton? _instance;
        public List<Additive> Additives { get; set; }
        public List<Order> Orders { get; set; }
        public List<IceCream> IceCreams { get; set; }
        public List<Shop> Shops { get; set; }
		public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfos { get; set; }

        private DataListSingleton()
        {
            Additives = new List<Additive>();
            Orders = new List<Order>();
            IceCreams = new List<IceCream>();
            Shops = new List<Shop>();
            Clients = new List<Client>();
            Implementers = new();
            MessageInfos = new();
        }

        public static DataListSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataListSingleton();
            }
            return _instance;
        }
    }
}