using AutoMapper;
using Final.BL.DTOs.ProductSizeDTOs;
using Final.BL.Exceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.Data.Repository.Abstractions;

namespace Final.BL.Services.Implementations
{
    public class ProductSizeService : IProductSizeService
    {
        public readonly IProductSizeRepository _productSizeRepository;
        public readonly IMapper _mapper;
        public ProductSizeService(IProductSizeRepository productSizeRepository, IMapper mapper)
        {
            _productSizeRepository = productSizeRepository;
            _mapper = mapper;
        }

        public async Task<ProductSize> CreateProductSizeAsync(ProductSizeCreateDTO dto)
        {
            ProductSize createdProductSize = _mapper.Map<ProductSize>(dto);
            createdProductSize.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _productSizeRepository.CreateAsync(createdProductSize);
            await _productSizeRepository.Save();
            return createdProductSize;
        }

        public async Task<ICollection<ProductSize>> GetAllProductSizeAsync()
        {
            return await _productSizeRepository.GetAllAsync();
        }

        public async Task<ProductSize> GetProductSizeByIdAsync(int id)
        {
            if (!await _productSizeRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _productSizeRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteProductSizeAsync(int id)
        {
            ProductSize productSizeEntity = await GetProductSizeByIdAsync(id);
            _productSizeRepository.SoftDelete(productSizeEntity);
            _productSizeRepository.Update(productSizeEntity);
            await _productSizeRepository.Save();
            return true;
        }

        public async Task<bool> UpdateProductSizeAsync(int id, ProductSizeCreateDTO dto)
        {
            var productSizeEntity = await GetProductSizeByIdAsync(id);
            ProductSize updatedProductSize = _mapper.Map<ProductSize>(dto);
            updatedProductSize.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedProductSize.Id = id;
            _productSizeRepository.Update(updatedProductSize);
            await _productSizeRepository.Save();
            return true;
        }


    }
}
