using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;

namespace LinuxParking.API.Utils
{
    public static class Jwt
    {
        public static string GenerateToken(IdentityUser user, string secret)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secret);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                  {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    // Refresh token for later use
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(descriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        public static string GetClaims(string token, string type)
        {
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadToken(token) as JwtSecurityToken;

            var value = securityToken.Claims.First(c => c.Type == type).Value;
            return value;
        }
    }
}