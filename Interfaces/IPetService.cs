using backend.Dtos;

namespace backend.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<PetDto>> GetPets();
        Task<PetDto?> GetPetById(int id);
        Task<bool> AddPet(PetDto petDto);
        Task<bool> UpdatePet(PetDto petDto);
        Task<bool> DeletePet(int id);
    }
}