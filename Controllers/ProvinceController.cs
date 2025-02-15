using backend.Dtos;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly ICityService _provinceService;

        public ProvinceController(ICityService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetProvinces(int? provinceId, string? provinceName)
        {
            try
            {
                var provinces = await _provinceService.GetProvince(provinceId, provinceName);
                return Ok(provinces);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddProvince([FromBody] ProvinceDto provinceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _provinceService.AddProvince(provinceDto);
                if (result)
                {
                    return Ok("Province added successfully.");
                }

                return BadRequest("Failed to add province.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateProvince([FromBody] ProvinceDto provinceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _provinceService.UpdateProvince(provinceDto);
                if (result)
                {
                    return Ok("Province updated successfully.");
                }

                return NotFound("Province not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{provinceId}")]
        [Authorize]
        public async Task<ActionResult> DeleteProvince(int provinceId)
        {
            try
            {
                var result = await _provinceService.DeleteProvince(provinceId);
                if (result)
                {
                    return Ok("Province deleted successfully.");
                }

                return NotFound("Province not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}