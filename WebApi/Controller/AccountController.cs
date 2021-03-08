using Entity.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Token([FromBody] User user)
        //{
        //    var identity = await GetIdentityAsync(user);
        //    if (identity == null)
        //    {
        //        return BadRequest(new { errorText = "Invalid username or password." });
        //    }

        //    var now = DateTime.UtcNow;

        //    var jwt = new JwtSecurityToken(
        //            issuer: AuthOptions.ISSUER,
        //            audience: AuthOptions.AUDIENCE,
        //            notBefore: now,
        //            claims: identity.Claims,
        //            expires: now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
        //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    var response = new
        //    {
        //        access_token = encodedJwt,
        //        username = identity.Name
        //    };

        //    return Ok(new
        //    {
        //        token = encodedJwt,
        //        login = identity.Name
        //    });
        //}

        //private async Task<ClaimsIdentity> GetIdentityAsync(User user)
        //{
        //    user = await UserRepository.GetUserByLoginAndPasswordAsync(user);

        //    if (user != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
        //            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
        //        };
        //        ClaimsIdentity claimsIdentity =
        //        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //            ClaimsIdentity.DefaultRoleClaimType);
        //        return claimsIdentity;
        //    }

        //    return null;
        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await UserRepository.GetUserByLoginAndPasswordAsync(new Entity.Model.User("Admin", "admin")));
        }
    }
}
