using AutoMapper;
using Final.BL.DTOs.ProductDTOs;
using Final.BL.Exceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.Data.Repository.Abstractions;
using Final.Data.Repository.Implementations;
using Microsoft.AspNetCore.Hosting;

namespace Final.BL.Services.Implementations
{
    public class ProductService:IProductService
    {
        public readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Product> CreateProductAsync(ProductCreateDTO dto)
        {
            if (dto.ImagePath is null)
            {
                throw new Exception("File Not Found");
            }
            string fileName = Path.GetFileNameWithoutExtension(dto.ImagePath.FileName);
            if (dto.ImagePath.Length > 1 * 1024 * 1024)
            {
                throw new Exception("File is too big");
            }
            string[] allowedFormat = [".jpg", ".png", "jpeg", ".svg", ".webp"];
            string extension = Path.GetExtension(dto.ImagePath.FileName);
            bool isAllowed=false;
            foreach (string format in allowedFormat)
            {
                if (format == extension)
                {
                    isAllowed = true;
                    break;
                }
            }
            if (!isAllowed)
            {
                throw new Exception("invalid format");
            }

            string uploadPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            if (Path.Exists(Path.Combine(uploadPath, fileName + extension)))
            {
                fileName = fileName + Guid.NewGuid().ToString();
            }
            fileName = fileName + extension;
            uploadPath = Path.Combine(uploadPath, fileName);
            using FileStream fileStream = new FileStream(uploadPath, FileMode.Create);
            

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
