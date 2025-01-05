using AutoMapper;
using Final.BL.DTOs.ProductColorDTOs;
using Final.BL.Exceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.Data.Repository.Abstractions;
using Final.Data.Repository.Implementations;

namespace Final.BL.Services.Implementations
{
    public class ProductColorService:IProductColorService
    {
        public readonly IProductColorRepository _productColorRepository;
        public readonly IMapper _mapper;
        public ProductColorService(IProductColorRepository productColorRepository, IMapper mapper)
        {
            _productColorRepository = productColorRepository;
            _mapper = mapper;
        }

        public async Task<ProductColor> CreateProductColorAsync(ProductColorCreateDTO dto)
        {
            ProductColor createdProductColor = _mapper.Map<ProductColor>(dto);
            createdProductColor.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _productColorRepository.CreateAsync(createdProductColor);
            await _productColorRepository.Save();
            return createdProductColor;
        }

        public async Task<ICollection<ProductColor>> GetAllProductColorAsync()
        {
            return await _productColorRepository.GetAllAsync();
        }

        public async Task<ProductColor> GetProductColorByIdAsync(int id)
        {
            if (!await _productColorRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _productColorRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteProductColorAsync(int id)
        {
            ProductColor productColorEntity = await GetProductColorByIdAsync(id);
            _productColorRepository.SoftDelete(productColorEntity);
            _productColorRepository.Update(productColorEntity);

            await _productColorRepository.Save();
            return true;
        }

        public async Task<bool> UpdateProductColorAsync(int id, ProductColorCreateDTO dto)
        {
            var productColorEntity = await GetProductColorByIdAsync(id);
            ProductColor updatedProductColor = _mapper.Map<ProductColor>(dto);
            updatedProductColor.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedProductColor.Id = id;
            _productColorRepository.Update(updatedProductColor);
            await _productColorRepository.Save();
            return true;
        }
    }
}
