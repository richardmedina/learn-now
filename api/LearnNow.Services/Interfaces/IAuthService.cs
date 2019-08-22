using LearnNow.Contracts;
using LearnNow.Contracts.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnNow.Services.Interfaces
{
    public interface IAuthService
    {
        Task<GenericServiceResult<JwtTokenInfo>> Authorize(AuthorizeDto authorizeDto);
    }
}
