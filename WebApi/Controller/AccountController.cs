using Entity.Interface;
using Entity.Model;
using Entity.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Model.Dto;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserRepository UserRepository { get; set; }


        public AccountController(
            IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Token([FromBody] UserAuth user)
        {
            var identity = await GetIdentityAsync(user);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                token = encodedJwt,
                login = identity.Name
            });
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(IUserAuth user)
        {
            var User = await UserRepository.GetUserByLoginAndPasswordAsync(user);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, User.Name),
                    new Claim("userId", User.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, User.Role.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
