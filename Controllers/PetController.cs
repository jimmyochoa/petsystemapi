using backend.Dtos;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PetDto>>> GetPets()
        {
            try
            {
                var pets = await _petService.GetPets();
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PetDto>> GetPetById(int id)
        {
            try
            {
                var pet = await _petService.GetPetById(id);
                if (pet == null)
                {
                    return NotFound("Pet not found.");
                }

                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddPet([FromBody] PetDto petDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _petService.AddPet(petDto);
                if (result)
                {
                    return Ok("Pet added successfully.");
                }

                return BadRequest("Failed to add pet.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdatePet([FromBody] PetDto petDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _petService.UpdatePet(petDto);
                if (result)
                {
                    return Ok("Pet updated successfully.");
                }

                return NotFound("Pet not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletePet(int id)
        {
            try
            {
                var result = await _petService.DeletePet(id);
                if (result)
                {
                    return Ok("Pet deleted successfully.");
                }

                return NotFound("Pet not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}