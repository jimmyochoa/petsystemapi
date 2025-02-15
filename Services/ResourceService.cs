using backend.Dtos;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ResourceService : IResourceService
    {
        private readonly PetSystemContext _context;

        public ResourceService(PetSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResourceDto>> GetResources()
        {
            return await _context.Resources
                .Select(r => new ResourceDto
                {
                    ResourceId = r.ResourceId,
                    ResourceName = r.ResourceName,
                    Description = r.Description,
                    IsActive = r.IsActive
                }).ToListAsync();
        }

        public async Task<ResourceDto?> GetResourceById(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource == null) return null;

            return new ResourceDto
            {
                ResourceId = resource.ResourceId,
                ResourceName = resource.ResourceName,
                Description = resource.Description,
                IsActive = resource.IsActive
            };
        }

        public async Task<bool> AddResource(ResourceDto resourceDto)
        {
            var resource = new Resource
            {
                ResourceName = resourceDto.ResourceName,
                Description = resourceDto.Description,
                IsActive = resourceDto.IsActive,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            _context.Resources.Add(resource);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateResource(ResourceDto resourceDto)
        {
            var resource = await _context.Resources.FindAsync(resourceDto.ResourceId);
            if (resource == null) return false;

            resource.ResourceName = resourceDto.ResourceName;
            resource.Description = resourceDto.Description;
            resource.IsActive = resourceDto.IsActive;
            resource.ModifiedAt = DateTime.UtcNow;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteResource(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            if (resource == null) return false;

            resource.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}