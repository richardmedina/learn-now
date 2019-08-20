using LearnNow.Api.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LearnNow.Contracts.User;
using LearnNow.Services.Interfaces;

namespace LearnNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequest request)
        {
            await _userService.CreateAsync(new CreateUserDto
            {
                UserName =  request.UserName,
                Password =  request.Password
            });

            return Created("uri", "value");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(long userId)
        {
            await Task.Yield();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            await Task.Yield();
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete()
        {
            await Task.Yield();

            return Ok();
        }
    }
}
