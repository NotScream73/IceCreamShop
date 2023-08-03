using System.ComponentModel.DataAnnotations;

namespace IceCreamShopDatabaseImplement.Models
{
    public class ShopIceCream
    {
        public int Id { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        public int IceCreamId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Shop Shop { get; set; } = new();

        public virtual IceCream IceCream { get; set; } = new();
    }
}
