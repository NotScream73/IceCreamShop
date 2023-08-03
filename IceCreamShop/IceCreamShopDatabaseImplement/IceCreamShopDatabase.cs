using IceCreamShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace IceCreamShopDatabaseImplement
{
    public class IceCreamShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JS88CIM\SQLEXPRESS;Initial Catalog=IceCreamShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Additive> Additives { set; get; }

        public virtual DbSet<IceCream> IceCreams { set; get; }

        public virtual DbSet<IceCreamAdditive> IceCreamAdditives { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Shop> Shops { set; get; }

        public virtual DbSet<ShopIceCream> ShopIceCreams { get; set; }

		public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
        public virtual DbSet<MessageInfo> MessageInfos { set; get; }
    }
}
