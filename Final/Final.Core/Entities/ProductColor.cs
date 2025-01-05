using Final.Core.Entities.Base;

namespace Final.Core.Entities
{
    public class ProductColor:AuditableEntity
    {

        public int ProductId {  get; set; }

        public int ColorId {  get; set; }   
        public Product? Product { get; set; }

        public Color? Color { get; set; }


    }
}
