using backend.Dtos;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class CareTaskService : ICareTaskService
    {
        private readonly PetSystemContext _context;

        public CareTaskService(PetSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CareTaskDto>> GetCareTasks()
        {
            return await _context.CareTasks
                .Select(ct => new CareTaskDto
                {
                    CareTaskId = ct.CareTaskId,
                    Name = ct.Name,
                    Description = ct.Description,
                    IsActive = ct.IsActive
                }).ToListAsync();
        }

        public async Task<CareTaskDto?> GetCareTaskById(int id)
        {
            var careTask = await _context.CareTasks.FindAsync(id);
            if (careTask == null) return null;

            return new CareTaskDto
            {
                CareTaskId = careTask.CareTaskId,
                Name = careTask.Name,
                Description = careTask.Description,
                IsActive = careTask.IsActive
            };
        }

        public async Task<bool> AddCareTask(CareTaskDto careTaskDto)
        {
            var careTask = new CareTask
            {
                Name = careTaskDto.Name,
                Description = careTaskDto.Description,
                IsActive = careTaskDto.IsActive,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            _context.CareTasks.Add(careTask);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCareTask(CareTaskDto careTaskDto)
        {
            var careTask = await _context.CareTasks.FindAsync(careTaskDto.CareTaskId);
            if (careTask == null) return false;

            careTask.Name = careTaskDto.Name;
            careTask.Description = careTaskDto.Description;
            careTask.IsActive = careTaskDto.IsActive;
            careTask.ModifiedAt = DateTime.UtcNow;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCareTask(int id)
        {
            var careTask = await _context.CareTasks.FindAsync(id);
            if (careTask == null) return false;

            _context.CareTasks.Remove(careTask);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AssignTaskToUser(int taskId, int userId)
        {
            var userCareTask = new UserCareTask
            {
                UserId = userId,
                CareTaskId = taskId,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.UserCareTasks.Add(userCareTask);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CompleteTask(int taskId)
        {
            var task = await _context.CareTasks.FindAsync(taskId);
            if (task == null) return false;

            task.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}