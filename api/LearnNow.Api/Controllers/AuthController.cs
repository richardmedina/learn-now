using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnNow.Api.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LearnNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private string AuthKey = "This is just another longer key";
        private string Issuer = "issuer";
        private string Audience = "audience";
        // POST: api/Auth
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequestModel request)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes (AuthKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            var tokenBuildInfo = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: null,
                expires: expiration,
                signingCredentials: creds
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenBuildInfo);


            return Ok(new AuthResponseModel {
                Token = token,
                Expiration = expiration
            });
        }
    }
}
