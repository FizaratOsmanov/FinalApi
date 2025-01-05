using AutoMapper;
using Final.BL.DTOs.AppUserDTOs;
using Final.BL.Exceptions;
using Final.BL.ExternalServices.Abstractions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Final.BL.Services.Implementations
{
    public class AccountService:IAccountService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,ITokenService tokenService, IMapper mapper)
        {          
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAsync(AppUserCreateDTO dto)
        {
            MailAddress email = new MailAddress(dto.Email);
            string pattern = @"^\+994(50|51|55|70|77)\d{7}$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(dto.PhoneNumber))
            {
                throw new Exception("Phone number is not valid");
            }

            AppUser appUser = _mapper.Map<AppUser>(dto);
            if (string.IsNullOrEmpty(appUser.UserName))
            {
                throw new Exception("UserName is required.");
            }
            if (string.IsNullOrEmpty(appUser.Email))
            {
                throw new Exception("Email is required.");
            }
            if (!new EmailAddressAttribute().IsValid(appUser.Email))
            {
                throw new Exception("Email is not valid.");
            }
            var result = await _userManager.CreateAsync(appUser, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User creation failed.");
            }
            return true;
        }
        public async Task<string> LoginAsync(LoginDTO dto)
        {
            AppUser? user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }

            bool result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result)
            {
                throw new Exception("Username or password is wrong");
            }
            string token = _tokenService.GenerateToken(user);
            return token;
        }

        public async Task<ICollection<AppUserCreateDTO>> GetAllUsersAsync()
        {
            ICollection<AppUser> users = await _userManager.Users.ToListAsync();
            ICollection<AppUserCreateDTO> allUsers = _mapper.Map<ICollection<AppUserCreateDTO>>(users);
            return allUsers;
        }

        public async Task<AppUserCreateDTO> GetOneUserAsync(string userName)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u =>u.UserName==userName);
            AppUserCreateDTO oneUser = _mapper.Map<AppUserCreateDTO>(user);
            return oneUser;
        }

        public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }
        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("Invalid user ID.");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                throw new Exception("Email confirmation failed");
            }
            return true;
        }
    }
}
