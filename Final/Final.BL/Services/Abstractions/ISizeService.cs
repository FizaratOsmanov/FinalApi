using Final.BL.DTOs.ProductSizeDTOs;
using Final.BL.DTOs.SizeDTOs;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions
{
    public interface ISizeService
    {
        Task<ICollection<Size>> GetAllSizeAsync();
        Task<Size> CreateSizeAsync(SizeCreateDTO dto);
        Task<Size> GetSizeByIdAsync(int id);
        Task<bool> SoftDeleteSizeAsync(int id);
        Task<bool> UpdateSizeAsync(int id, SizeCreateDTO dto);
    }
}
