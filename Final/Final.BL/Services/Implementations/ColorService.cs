using AutoMapper;
using Final.BL.DTOs.ColorDTOs;
using Final.BL.Exceptions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.Data.Repository.Abstractions;
using Final.Data.Repository.Implementations;

namespace Final.BL.Services.Implementations
{
    public class ColorService : IColorService
    {
        public readonly IColorRepository _colorRepository;
        public readonly IMapper _mapper;
        public ColorService(IColorRepository colorRepository,IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<Color> CreateColorAsync(ColorCreateDTO dto)
        {
            Color createdColor = _mapper.Map<Color>(dto);
            createdColor.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _colorRepository.CreateAsync(createdColor);
            await _colorRepository.Save();
            return createdColor;
        }

        public async Task<ICollection<Color>> GetAllColorAsync()
        {
            return await _colorRepository.GetAllAsync();
        }

        public async Task<Color> GetColorByIdAsync(int id)
        {
            if (!await _colorRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _colorRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteColorAsync(int id)
        {
            Color colorEntity=await GetColorByIdAsync(id);
            _colorRepository.SoftDelete(colorEntity);
            _colorRepository.Update(colorEntity);

            await _colorRepository.Save();
            return true;
        }

        public async Task<bool> UpdateColorAsync(int id, ColorCreateDTO dto)
        {
            var colorEntity = await GetColorByIdAsync(id);
            Color updatedColor = _mapper.Map<Color>(dto);
            updatedColor.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedColor.Id = id;
            _colorRepository.Update(updatedColor);
            await _colorRepository.Save();
            return true;
        }
    }
}
