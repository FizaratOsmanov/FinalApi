using Final.BL.DTOs.CategoryDTOs;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status200OK, await _categoryService.CreateCategoryAsync(dto));
        }

        [HttpGet("GetAll")]
        public async Task<ICollection<Category>> GetAllCategory()
        {
            return await _categoryService.GetAllCategoryAsync();
        }


        [HttpGet("{id}")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryService.GetCategoryByIdAsync(id);
        }


        [HttpDelete("{id}")]
        public async Task<bool> DeleteCatagory(int id)
        {
            return await _categoryService.SoftDeleteCategoryAsync(id);
        }


        [HttpPut("{id}")]
        public async Task<bool> UpdateCategory(int id, CategoryCreateDTO dto)
        {
            return await _categoryService.UpdateCategoryAsync(id, dto);

        }
    }
}
