using backend.Dtos;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetResources()
        {
            try
            {
                var resources = await _resourceService.GetResources();
                return Ok(resources);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ResourceDto>> GetResourceById(int id)
        {
            try
            {
                var resource = await _resourceService.GetResourceById(id);
                if (resource == null)
                {
                    return NotFound("Resource not found.");
                }

                return Ok(resource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddResource([FromBody] ResourceDto resourceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _resourceService.AddResource(resourceDto);
                if (result)
                {
                    return CreatedAtAction(nameof(GetResourceById), new { id = resourceDto.ResourceId }, resourceDto);
                }

                return BadRequest("Failed to add resource.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateResource([FromBody] ResourceDto resourceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _resourceService.UpdateResource(resourceDto);
                if (result)
                {
                    return Ok("Resource updated successfully.");
                }

                return NotFound("Resource not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteResource(int id)
        {
            try
            {
                var result = await _resourceService.DeleteResource(id);
                if (result)
                {
                    return Ok("Resource deleted successfully.");
                }

                return NotFound("Resource not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}