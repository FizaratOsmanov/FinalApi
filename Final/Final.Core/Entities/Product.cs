using Final.Core.Entities.Base;

namespace Final.Core.Entities
{
    public class Product: AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int AppUserId {  get; set; }
        public int CategoryId { get; set; }
        public AppUser? AppUser { get; set; }
        public Category? Category { get; set; }
        public ICollection<ProductSize>? ProductSizes { get; set; }
        public ICollection<ProductColor>? ProductColors { get; set; }
        public string? ImagePath { get; set; } 
    }
}
