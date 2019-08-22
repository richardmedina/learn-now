using LearnNow.Contracts;
using LearnNow.Contracts.Auth;
using LearnNow.Domain;
using LearnNow.Services.Abstract;
using LearnNow.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace LearnNow.Services.Auth
{
    public class AuthService : AbstractService, IAuthService
    {
        private string AuthKey = "This is just another longer key";
        private string Issuer = "issuer";
        private string Audience = "audience";

        private readonly IUserService _userService;

        public AuthService(LearnNowDbContext context, IUserService userService) : base (context)
        {
            _userService = userService;
        }

        public async Task<GenericServiceResult<JwtTokenInfo>> Authorize(AuthorizeDto authorizeDto)
        {
            var user = await _userService.GetByUsernameAsync(authorizeDto.UserName);

            if (user.CodeResult == CodeResult.Error || user.Result == null || user.Result.Password != authorizeDto.Password)
            {
                return GetFailedResult<JwtTokenInfo>(new ErrorMessage ("Unathorized"));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthKey));
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

            var tokenInfo = new JwtTokenInfo
            {
                Token = token,
                Expiration = expiration
            };

            return GetSuccessResult(tokenInfo);
        }
    }
}
