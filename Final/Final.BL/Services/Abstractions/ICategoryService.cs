using Final.BL.DTOs.CategoryDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllCategoryAsync();
        Task<Category> CreateCategoryAsync(CategoryCreateDTO dto);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> SoftDeleteCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, CategoryCreateDTO dto);
    }
}
