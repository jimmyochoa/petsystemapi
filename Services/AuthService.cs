using backend.Dtos;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly PetSystemContext _context;

        public AuthService(PetSystemContext context)
        {
            _context = context;
        }

        public async Task<string?> AuthenticateUser(LoginDto loginDto)
        {

            var user = await (from u in _context.Users
                              where u.Email == loginDto.Email
                              select u).FirstOrDefaultAsync();

            if (!(user.Email == loginDto.Email))
            {
                return null;
            }

            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return null;
            }

            JWTHelper _jwtHelper = new JWTHelper();

            return _jwtHelper.GenerateJwtToken(user.FirstName);
        }

        public async Task<Boolean> RegisterUser(RegisterDto registerDto)
        
        {
            var existingUser = await (from u in _context.Users
                                      where u.Email == registerDto.Email
                                      select u).FirstOrDefaultAsync();
            if (existingUser != null)
                return false;
            
            if (registerDto.ProvinceId == 0)
                return false;

            var newUser = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Password = registerDto.Password,
                Direction = registerDto.Direction,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true,
                ProvinceId = registerDto.ProvinceId
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
