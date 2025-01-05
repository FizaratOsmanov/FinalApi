using Final.BL.DTOs.ColorDTOs;
using Final.Core.Entities;

namespace Final.BL.Services.Abstractions
{
    public interface IColorService
    {
        Task<ICollection<Color>> GetAllColorAsync();
        Task<Color> CreateColorAsync(ColorCreateDTO dto);
        Task<Color> GetColorByIdAsync(int id);
        Task<bool> SoftDeleteColorAsync(int id);
        Task<bool> UpdateColorAsync(int id, ColorCreateDTO dto);
    }
}
