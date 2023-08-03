using IceCreamShopFileImplement.Models;
using System.Xml.Linq;

namespace IceCreamShopFileImplement
{
    public class DataFileSingleton
    {
        private static DataFileSingleton? instance;
        private readonly string AdditiveFileName = "Additive.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string IceCreamFileName = "IceCream.xml";
		private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string MessageInfoFileName = "MessageInfo.xml";
        public List<Additive> Additives { get; private set; }
		private readonly string ShopFileName = "Shop.xml";
        public List<Order> Orders { get; private set; }
        public List<IceCream> IceCreams { get; private set; }
        public List<Shop> Shops { get; private set; }
		public List<Client> Clients { get; private set; }
        public List<Implementer> Implementers { get; private set; }
        public List<MessageInfo> MessageInfos { get; private set; }

        public static DataFileSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataFileSingleton();
            }
            return instance;
        }

        public void SaveAdditives() => SaveData(Additives, AdditiveFileName, "Additives", x => x.GetXElement);
        public void SaveIceCreams() => SaveData(IceCreams, IceCreamFileName, "IceCreams", x => x.GetXElement);
        public void SaveOrders() => SaveData(Orders, OrderFileName, "Orders", x => x.GetXElement);
        public void SaveShops() => SaveData(Shops, ShopFileName, "Shops", x => x.GetXElement);
		public void SaveClients() => SaveData(Clients, ClientFileName, "Clients", x => x.GetXElement);
        public void SaveImplementers() => SaveData(Implementers, ImplementerFileName, "Implementers", x => x.GetXElement);
        public void SaveMessageInfos() => SaveData(MessageInfos, MessageInfoFileName, "MessageInfos", x => x.GetXElement);
        private DataFileSingleton()
        {
            Additives = LoadData(AdditiveFileName, "Additive", x => Additive.Create(x)!)!;
            IceCreams = LoadData(IceCreamFileName, "IceCream", x => IceCream.Create(x)!)!;
            Orders = LoadData(OrderFileName, "Order", x => Order.Create(x)!)!;
            Shops = LoadData(ShopFileName, "Shop", x => Shop.Create(x)!)!;
            Clients = LoadData(ClientFileName, "Client", x => Client.Create(x)!)!;
            Implementers = LoadData(ImplementerFileName, "Implementer", x => Implementer.Create(x)!)!;
            MessageInfos = LoadData(MessageInfoFileName, "MessageInfo", x => MessageInfo.Create(x)!)!;
        }
        private static List<T>? LoadData<T>(string filename, string xmlNodeName, Func<XElement, T> selectFunction)
        {
            if (File.Exists(filename))
            {
                return XDocument.Load(filename)?.Root?.Elements(xmlNodeName)?.Select(selectFunction)?.ToList();
            }
            return new List<T>();
        }
        private static void SaveData<T>(List<T> data, string filename, string xmlNodeName, Func<T, XElement> selectFunction)
        {
            if (data != null)
            {
                new XDocument(new XElement(xmlNodeName, data.Select(selectFunction).ToArray())).Save(filename);
            }
        }
    }
}