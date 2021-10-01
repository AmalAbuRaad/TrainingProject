using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainingWebApp.Data;
using TrainingWebApp.ViewModels;

namespace TrainingWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IConfiguration _configuration;

        public AccountsController(IDbContextFactory<ApplicationDbContext> contextFactory, IConfiguration configuration)
        {
            _contextFactory = contextFactory;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginVM)
        {
            using (var _context = _contextFactory.CreateDbContext()) {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginVM.UserName);
                var password = await _context.Users.FirstOrDefaultAsync(x => x.Password.Contains(loginVM.Password));
                if (user != null && password != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                                new Claim(ClaimTypes.Name, loginVM.UserName),
                                new Claim("id", loginVM.Id.ToString())
                            }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return Ok(new
                    {
                        token = tokenHandler.WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                return BadRequest(new { message = "Username or password is incorrect" });

            } 
          }
        }   
}
