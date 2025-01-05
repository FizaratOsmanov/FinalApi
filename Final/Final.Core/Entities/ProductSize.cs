using Final.Core.Entities.Base;

namespace Final.Core.Entities
{
    public class ProductSize:AuditableEntity
    {
        public Product? Product { get; set; }
        public Size? Size { get; set; }

        public int ProductId { get; set; }

        public int SizeId { get; set; }
    }
}
