using Final.BL.DTOs.AppUserDTOs;
using Final.BL.Exceptions;
using Final.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        readonly IAccountService _service;
        public AccountsController(IAccountService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            ICollection<AppUserCreateDTO> allUsers = await _service.GetAllUsersAsync();
            return Ok(allUsers);
        }


        [HttpGet("User")]
        public async Task<IActionResult> GetOneUser(string user)
        {
            AppUserCreateDTO oneUser= await _service.GetOneUserAsync(user);
            return Ok(oneUser);
        }

        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                throw new Exception("Error");
            }
            var result = await _service.ConfirmEmailAsync(userId, token);
            if (result)
            {
                return Ok("Successfully");
            }
            return BadRequest("Error");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(AppUserCreateDTO dto)
        {
            await _service.RegisterAsync(dto);
            return Ok();
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input.");
            }
            await _service.ChangePasswordAsync(dto.Email, dto.OldPassword, dto.NewPassword);
            return Ok();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _service.LoginAsync(dto));
            }
            catch (EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not found");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
