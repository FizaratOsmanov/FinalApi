using Final.BL.DTOs.ProductDTOs;
using Final.Core.Entities;

namespace Final.BL.Services.Abstractions
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllProductAsync();
        Task<Product> CreateProductAsync(ProductCreateDTO dto);
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> SoftDeleteProductAsync(int id);
        Task<bool> UpdateProductAsync(int id, ProductCreateDTO dto);
    }
}
