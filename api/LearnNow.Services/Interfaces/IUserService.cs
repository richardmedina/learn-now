using System.Collections.Generic;
using LearnNow.Contracts.User;
using System.Threading.Tasks;
using LearnNow.Contracts;

namespace LearnNow.Services.Interfaces
{
    public interface IUserService
    {

        Task<GenericServiceResult<UserDto>> CreateAsync(CreateUserDto createUserDto);
        Task<GenericServiceResult<IEnumerable<UserDto>>> GetAllAsync();
        Task<GenericServiceResult<UserDto>> GetByUsernameAsync(string username);
    }
}
