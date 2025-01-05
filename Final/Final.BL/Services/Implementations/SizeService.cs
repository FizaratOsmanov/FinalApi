using AutoMapper;
using Final.BL.DTOs.SizeDTOs;
using Final.BL.Exceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.Data.Repository.Abstractions;
using Final.Data.Repository.Implementations;

namespace Final.BL.Services.Implementations
{
    public class SizeService : ISizeService
    {
        public readonly ISizeRepository _sizeRepository;
        public readonly IMapper _mapper;
        public SizeService(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<Size> CreateSizeAsync(SizeCreateDTO dto)
        {
            Size createdSize = _mapper.Map<Size>(dto);
            createdSize.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _sizeRepository.CreateAsync(createdSize);
            await _sizeRepository.Save();
            return createdSize;
        }

        public async Task<ICollection<Size>> GetAllSizeAsync()
        {
            return await _sizeRepository.GetAllAsync();
        }

        public async Task<Size> GetSizeByIdAsync(int id)
        {
            if (!await _sizeRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _sizeRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteSizeAsync(int id)
        {
            Size sizeEntity = await GetSizeByIdAsync(id);
            _sizeRepository.SoftDelete(sizeEntity);
            _sizeRepository.Update(sizeEntity);
            await _sizeRepository.Save();
            return true;
        }

        public async Task<bool> UpdateSizeAsync(int id, SizeCreateDTO dto)
        {
            var sizeEntity = await GetSizeByIdAsync(id);
            Size updatedSize = _mapper.Map<Size>(dto);
            updatedSize.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedSize.Id = id;
            _sizeRepository.Update(updatedSize);
            await _sizeRepository.Save();
            return true;
        }
    }
}
