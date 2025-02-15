using backend.Dtos;

namespace backend.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto?> GetUserById(int id);
        Task<bool> AddUser(UserDto userDto);
        Task<bool> UpdateUser(UserDto userDto);
        Task<bool> DeleteUser(int id);
    }
}