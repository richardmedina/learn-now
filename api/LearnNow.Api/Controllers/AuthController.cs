using AutoMapper;
using LearnNow.Api.Models.Auth;
using LearnNow.Contracts;
using LearnNow.Contracts.Auth;
using LearnNow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearnNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public AuthController(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        // POST: api/Auth
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthRequestModel request)
        {
            var result = await _authService.Authorize(_mapper.Map<AuthorizeDto>(request));

            if (result.CodeResult == CodeResult.Success)
            {
                return Ok(result.Result);
            }

            return Unauthorized();
        }
    }
}
