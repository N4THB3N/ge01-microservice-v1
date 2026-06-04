using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UserService.Models;

namespace UserService.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        DateTime GetTokenExpirationTime();
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly int _expirationMinutes = 60;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            var expirationConfig = _configuration["JwtSettings:ExpirationMinutes"];
            if (int.TryParse(expirationConfig, out var minutes))
            {
                _expirationMinutes = minutes;
            }
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public DateTime GetTokenExpirationTime()
        {
            return DateTime.UtcNow.AddMinutes(_expirationMinutes);
        }
    }
}
