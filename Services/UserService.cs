using backend.Dtos;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly PetSystemContext _context;

        public UserService(PetSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Direction = u.Direction,
                    ProvinceId = u.ProvinceId,
                    IsActive = u.IsActive
                }).ToListAsync();
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Direction = user.Direction,
                ProvinceId = user.ProvinceId,
                IsActive = user.IsActive
            };
        }

        public async Task<bool> AddUser(UserDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Direction = userDto.Direction,
                ProvinceId = userDto.ProvinceId,
                IsActive = userDto.IsActive,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(UserDto userDto)
        {
            var user = await _context.Users.FindAsync(userDto.UserId);
            if (user == null) return false;

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.Direction = userDto.Direction;
            user.ProvinceId = userDto.ProvinceId;
            user.IsActive = userDto.IsActive;
            user.ModifiedAt = DateTime.UtcNow;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.IsActive = false;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}