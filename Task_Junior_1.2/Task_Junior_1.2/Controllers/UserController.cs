using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Task_Junior_1._2.Models;
using Task_Junior_1._2.Settings;

namespace Task_Junior_1._2.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Task_JuniorContext _context;

        public UserController(Task_JuniorContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create([FromBody] User user)
        {
            return Ok(BCrypt.Net.BCrypt.HashPassword(user.Password));
        }

        [HttpPost("login")]
        public ActionResult Login([FromForm] User user)
        {
            if (user.Password != "password")
            {
                return BadRequest();
            }

            var jwtSettings = new JwtSettings();

            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Role, "User"),
                }),
                Expires = DateTime.UtcNow.AddSeconds(jwtSettings.LifetimeInSeconds),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = jwtSettings.ValidIssuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return Ok
            (
                new { access_token = tokenHandler.WriteToken(token) }
            );
        }

    }
}
