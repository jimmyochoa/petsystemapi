using backend.Dtos;

namespace backend.Interfaces
{
    public interface IResourceService
    {
        Task<IEnumerable<ResourceDto>> GetResources();
        Task<ResourceDto?> GetResourceById(int id);
        Task<bool> AddResource(ResourceDto resourceDto);
        Task<bool> UpdateResource(ResourceDto resourceDto);
        Task<bool> DeleteResource(int id);
    }
}