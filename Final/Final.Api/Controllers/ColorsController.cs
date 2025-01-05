using Final.BL.DTOs.ColorDTOs;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }



        [HttpPost("Create")]
        public async Task<IActionResult> CreateColor(ColorCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            };
            return StatusCode(StatusCodes.Status200OK, await _colorService.CreateColorAsync(dto));
        }

        [HttpGet("GetAll")]
        public async Task<ICollection<Color>> GetAllColor()
        {
            return await _colorService.GetAllColorAsync();
        }


        [HttpGet("{id}")]
        public async Task<Color> GetColorById(int id)
        {
            return await _colorService.GetColorByIdAsync(id);
        }


        [HttpDelete("{id}")]
        public async Task<bool> DeleteColor(int id)
        {
            return await _colorService.SoftDeleteColorAsync(id);
        }


        [HttpPut("{id}")]
        public async Task<bool> UpdateColor(int id, ColorCreateDTO dto)
        {
            return await _colorService.UpdateColorAsync(id, dto);

        }
    }
}
