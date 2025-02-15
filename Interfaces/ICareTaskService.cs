using backend.Dtos;

namespace backend.Interfaces
{
    public interface ICareTaskService
    {
        Task<IEnumerable<CareTaskDto>> GetCareTasks();
        Task<CareTaskDto?> GetCareTaskById(int id);
        Task<bool> AddCareTask(CareTaskDto careTaskDto);
        Task<bool> UpdateCareTask(CareTaskDto careTaskDto);
        Task<bool> DeleteCareTask(int id);

        Task<bool> AssignTaskToUser(int taskId, int userId);
        Task<bool> CompleteTask(int taskId);
    }
}