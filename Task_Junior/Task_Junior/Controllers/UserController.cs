using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AwesomeBlog.Api.Settings;
using AwesomeBlog.Api.ViewModels;
using AwesomeBlog.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AwesomeBlog.Api.Controllers
{

    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateUserViewModel createUserViewModel)
        {
            return Ok(BCrypt.Net.BCrypt.HashPassword(createUserViewModel.Password));
        }

        [HttpPost("login")]
        public ActionResult Login([FromForm] LoginViewModel loginViewModel)
        {
            if (loginViewModel.Password != "password")
            {
                return BadRequest();
            }

            var jwtSettings = new JwtSettings();

            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, loginViewModel.UserName),
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
                Issuer = jwtSettings.ValidIssuer,
                Audience = loginViewModel.Audience
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