using Final.Core.Entities.Base;

namespace Final.Core.Entities
{
    public class Category: AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; } 
    }
}
