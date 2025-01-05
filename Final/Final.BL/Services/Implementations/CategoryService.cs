using AutoMapper;
using Final.BL.DTOs.CategoryDTOs;
using Final.BL.Exceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.Data.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Category> CreateCategoryAsync(CategoryCreateDTO dto)
        {
            Category createdCategory = _mapper.Map<Category>(dto);
            createdCategory.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _categoryRepository.CreateAsync(createdCategory);
            await _categoryRepository.Save();
            return createdEntity;
        }

        public async Task<ICollection<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            if (!await _categoryRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteCategoryAsync(int id)
        {
            var categoryEntity = await GetCategoryByIdAsync(id);
            _categoryRepository.SoftDelete(categoryEntity);
            _categoryRepository.Update(categoryEntity);
            await _categoryRepository.Save();
            return true;
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryCreateDTO dto)
        {
            var categoryEntity = await GetCategoryByIdAsync(id);
            Category updatedCategory = _mapper.Map<Category>(dto);
            updatedCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedCategory.Id = id;
            _categoryRepository.Update(updatedCategory);
            await _categoryRepository.Save();
            return true;
        }
    }
}
