using Final.BL.DTOs.ProductDTOs;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status200OK, await _productService.CreateProductAsync(dto));
        }

        [HttpGet("GetAll")]
        public async Task<ICollection<Product>> GetAllProduct()
        {
            return await _productService.GetAllProductAsync();
        }


        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }


        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            return await _productService.SoftDeleteProductAsync(id);
        }


        [HttpPut("{id}")]
        public async Task<bool> UpdateProduct(int id, ProductCreateDTO dto)
        {
            return await _productService.UpdateProductAsync(id, dto);

        }
    }
}
