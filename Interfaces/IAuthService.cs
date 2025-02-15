using backend.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IAuthService
    {
        Task<string?> AuthenticateUser(LoginDto loginDto);
        Task<Boolean> RegisterUser(RegisterDto registerDto);
    }
}
