using backend.Dtos;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareTaskController : ControllerBase
    {
        private readonly ICareTaskService _careTaskService;

        public CareTaskController(ICareTaskService careTaskService)
        {
            _careTaskService = careTaskService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CareTaskDto>>> GetCareTasks()
        {
            try
            {
                var careTasks = await _careTaskService.GetCareTasks();
                return Ok(careTasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CareTaskDto>> GetCareTaskById(int id)
        {
            try
            {
                var careTask = await _careTaskService.GetCareTaskById(id);
                if (careTask == null)
                {
                    return NotFound("Care task not found.");
                }

                return Ok(careTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddCareTask([FromBody] CareTaskDto careTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _careTaskService.AddCareTask(careTaskDto);
                if (result)
                {
                    return CreatedAtAction(nameof(GetCareTaskById), new { id = careTaskDto.CareTaskId }, careTaskDto);
                }

                return BadRequest("Failed to add care task.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateCareTask([FromBody] CareTaskDto careTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _careTaskService.UpdateCareTask(careTaskDto);
                if (result)
                {
                    return Ok("Care task updated successfully.");
                }

                return NotFound("Care task not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteCareTask(int id)
        {
            try
            {
                var result = await _careTaskService.DeleteCareTask(id);
                if (result)
                {
                    return NoContent();
                }

                return NotFound("Care task not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("assign")]
        [Authorize]
        public async Task<ActionResult> AssignTaskToUser(int taskId, int userId)
        {
            try
            {
                var result = await _careTaskService.AssignTaskToUser(taskId, userId);
                if (result)
                {
                    return Ok("Task assigned successfully.");
                }

                return BadRequest("Failed to assign task.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("complete")]
        [Authorize]
        public async Task<ActionResult> CompleteTask(int taskId)
        {
            try
            {
                var result = await _careTaskService.CompleteTask(taskId);
                if (result)
                {
                    return Ok("Task marked as completed.");
                }

                return BadRequest("Failed to complete task.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}