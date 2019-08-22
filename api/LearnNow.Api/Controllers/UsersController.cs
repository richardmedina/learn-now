using LearnNow.Api.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LearnNow.Contracts.User;
using LearnNow.Services.Interfaces;
using AutoMapper;

namespace LearnNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequestModel request)
        {
            var result = await _userService.CreateAsync(_mapper.Map<CreateUserDto>(request));

            return Created("uri", "value");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string reference)
        {
            var result = await (string.IsNullOrEmpty(reference)
                ? _userService.GetAllAsync()
                : _userService.GetByReferenceAsync(reference));

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(long userId)
        {
            var result = await _userService.GetByUserIdAsync(userId);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserRequestModel request)
        {
            var result = await _userService.UpdateAsync(_mapper.Map<UpdateUserDto>(request));

            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(long userId)
        {
            var result = await _userService.DeleteAsync(userId);
            
            return Ok();
        }
    }
}
