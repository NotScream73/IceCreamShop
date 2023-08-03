using System.ComponentModel.DataAnnotations;

namespace IceCreamShopDatabaseImplement.Models
{
    public class IceCreamAdditive
    {
        public int Id { get; set; }

        [Required]
        public int IceCreamId { get; set; }

        [Required]
        public int AdditiveId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Additive Additive { get; set; } = new();

        public virtual IceCream IceCream { get; set; } = new();
    }
}
