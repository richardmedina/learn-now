using LearnNow.Api.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnNow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequest request)
        {
            await Task.Yield();
            return Created("uri", "value");
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
