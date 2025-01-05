using Final.BL.DTOs.SizeDTOs;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }



        [HttpPost("Create")]
        public async Task<IActionResult> CreateSize(SizeCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status200OK, await _sizeService.CreateSizeAsync(dto));
        }

        [HttpGet("GetAll")]
        public async Task<ICollection<Size>> GetAllSize()
        {
            return await _sizeService.GetAllSizeAsync();
        }


        [HttpGet("{id}")]
        public async Task<Size> GetSizeById(int id)
        {
            return await _sizeService.GetSizeByIdAsync(id);
        }


        [HttpDelete("{id}")]
        public async Task<bool> DeleteSize(int id)
        {
            return await _sizeService.SoftDeleteSizeAsync(id);
        }


        [HttpPut("{id}")]
        public async Task<bool> UpdateSize(int id, SizeCreateDTO dto)
        {
            return await _sizeService.UpdateSizeAsync(id, dto);

        }
    }
}
