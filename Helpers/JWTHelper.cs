using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Helpers
{
    public class JWTHelper
    {
        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var keys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ju.=0yA*Hw=iu+t3}VSu%D0@D!XB>*(YTJASWA]s_E%/_,8).5WB59!/T{CtLe1"));
            var creedentials = new SigningCredentials(keys, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creedentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}