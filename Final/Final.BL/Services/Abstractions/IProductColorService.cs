using Final.BL.DTOs.ProductColorDTOs;
using Final.Core.Entities;

namespace Final.BL.Services.Abstractions
{
    public interface IProductColorService
    {
        Task<ICollection<ProductColor>> GetAllProductColorAsync();
        Task<ProductColor> CreateProductColorAsync(ProductColorCreateDTO dto);
        Task<ProductColor> GetProductColorByIdAsync(int id);
        Task<bool> SoftDeleteProductColorAsync(int id);
        Task<bool> UpdateProductColorAsync(int id, ProductColorCreateDTO dto);
    }
}
