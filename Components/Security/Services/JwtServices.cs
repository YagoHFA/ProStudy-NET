using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProStudy_NET.Models.DTO.UserDTO;
using ProStudy_NET.Models.Entities;

namespace ProStudy_NET.Component.Security.Services
{
    public class JwtServices
    {
        private readonly IConfiguration config;

        public JwtServices(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateToken(LoadUserDTO user)
        {
            string jwtKey = config["Jwt:Key"] ?? "my-secret-key";
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var role in user.RoleInfos)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.id));
            }
            
            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}