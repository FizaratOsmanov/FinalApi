using Microsoft.AspNetCore.Http;

namespace Final.BL.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public IFormFile? ImagePath { get; set; }


    }
}
