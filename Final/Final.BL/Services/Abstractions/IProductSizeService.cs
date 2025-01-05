using Final.BL.DTOs.ProductDTOs;
using Final.BL.DTOs.ProductSizeDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions
{
    public interface IProductSizeService
    {
        Task<ICollection<ProductSize>> GetAllProductSizeAsync();
        Task<ProductSize> CreateProductSizeAsync(ProductSizeCreateDTO dto);
        Task<ProductSize> GetProductSizeByIdAsync(int id);
        Task<bool> SoftDeleteProductSizeAsync(int id);
        Task<bool> UpdateProductSizeAsync(int id, ProductSizeCreateDTO dto);
    }
}
