
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Models;
using UserService.DTOs;
using UserService.Services;
using Microsoft.EntityFrameworkCore;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly UserContext _context;
        private readonly ITokenService _tokenService;

        public UsersController(UserContext userContext, ITokenService tokenService)
        {
            _context = userContext;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                return BadRequest("Username already exists");
            }

            user.SetPassword(user.Password);
            user.Created_At = DateTime.UtcNow;
            user.Updated_At = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.ID }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            
            if (user == null || !user.VerifyPassword(request.Password))
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _tokenService.GenerateToken(user);
            var authResponse = new AuthResponse
            {
                ID = user.ID,
                Username = user.Username,
                Email = user.Email,
                Token = token,
                ExpiresAt = _tokenService.GetTokenExpirationTime()
            };

            return Ok(authResponse);
        }
    }
}