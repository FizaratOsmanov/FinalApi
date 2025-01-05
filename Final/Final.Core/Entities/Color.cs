using Final.Core.Entities.Base;

namespace Final.Core.Entities
{
    public class Color: AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<ProductColor>? ProductColors { get; set; }

    }

}
