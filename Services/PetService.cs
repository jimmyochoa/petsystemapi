using backend.Dtos;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PetService : IPetService
    {
        private readonly PetSystemContext _context;

        public PetService(PetSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PetDto>> GetPets()
        {
            return await _context.Pets
                .Select(p => new PetDto
                {
                    PetId = p.PetId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Description = p.Description,
                    PetTypeId = p.PetTypeId,
                    IsActive = p.IsActive
                }).ToListAsync();
        }

        public async Task<PetDto?> GetPetById(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return null;

            return new PetDto
            {
                PetId = pet.PetId,
                FirstName = pet.FirstName,
                LastName = pet.LastName,
                Description = pet.Description,
                PetTypeId = pet.PetTypeId,
                IsActive = pet.IsActive
            };
        }

        public async Task<bool> AddPet(PetDto petDto)
        {
            var pet = new Pet
            {
                FirstName = petDto.FirstName,
                LastName = petDto.LastName,
                Description = petDto.Description,
                PetTypeId = petDto.PetTypeId,
                IsActive = petDto.IsActive,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            _context.Pets.Add(pet);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePet(PetDto petDto)
        {
            var pet = await _context.Pets.FindAsync(petDto.PetId);
            if (pet == null) return false;

            pet.FirstName = petDto.FirstName;
            pet.LastName = petDto.LastName;
            pet.Description = petDto.Description;
            pet.PetTypeId = petDto.PetTypeId;
            pet.IsActive = petDto.IsActive;
            pet.ModifiedAt = DateTime.UtcNow;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return false;

            pet.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}