using Final.Core.Entities.Base;

namespace Final.Core.Entities
{
    public class Size: AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<ProductSize>? ProductSizes { get; set; }
    }
}
