using backend.Dtos;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetCities(int? cityId, string? cityName, string? provinceName)
        {
            try
            {
                var cities = await _cityService.GetCities(cityId, cityName, provinceName);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddCity([FromBody] CityDto cityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _cityService.AddCity(cityDto);
                if (result)
                {
                    return Ok("City added successfully.");
                }

                return BadRequest("Failed to add city.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateCity([FromBody] CityDto cityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _cityService.UpdateCity(cityDto);
                if (result)
                {
                    return Ok("City updated successfully.");
                }

                return NotFound("City not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{cityId}")]
        [Authorize]
        public async Task<ActionResult> DeleteCity(int cityId)
        {
            try
            {
                var result = await _cityService.DeleteCity(cityId);
                if (result)
                {
                    return Ok("City deleted successfully.");
                }

                return NotFound("City not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}