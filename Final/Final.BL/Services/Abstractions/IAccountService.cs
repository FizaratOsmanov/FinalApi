using Final.BL.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(AppUserCreateDTO dto);
        Task<string> LoginAsync(LoginDTO dto);
        Task<bool> ConfirmEmailAsync(string userId, string token);
        Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword);
        Task<ICollection<AppUserCreateDTO>> GetAllUsersAsync();
        Task<AppUserCreateDTO> GetOneUserAsync(string userName);
    }
}
