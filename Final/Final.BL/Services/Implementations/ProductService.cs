using AutoMapper;
using Final.BL.DTOs.ProductDTOs;
using Final.BL.Exceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.Data.Repository.Abstractions;
using Final.Data.Repository.Implementations;

namespace Final.BL.Services.Implementations
{
    public class ProductService:IProductService
    {
        public readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(ProductCreateDTO dto)
        {
            Product createdProduct = _mapper.Map<Product>(dto);
            createdProduct.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _productRepository.CreateAsync(createdProduct);
            await _productRepository.Save();
            return createdProduct;
        }

        public async Task<ICollection<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            if (!await _productRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteProductAsync(int id)
        {
            Product productEntity = await GetProductByIdAsync(id);
            _productRepository.SoftDelete(productEntity);
            _productRepository.Update(productEntity);

            await _productRepository.Save();
            return true;
        }

        public async Task<bool> UpdateProductAsync(int id, ProductCreateDTO dto)
        {
            var productEntity = await GetProductByIdAsync(id);
            Product updatedProduct = _mapper.Map<Product>(dto);
            updatedProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedProduct.Id = id;
            _productRepository.Update(updatedProduct);
            await _productRepository.Save();
            return true;
        }
    }
}
