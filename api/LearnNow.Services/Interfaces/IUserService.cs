using System.Collections.Generic;
using LearnNow.Contracts.User;
using System.Threading.Tasks;
using LearnNow.Contracts;

namespace LearnNow.Services.Interfaces
{
    public interface IUserService
    {

        Task<GenericServiceResult<UserDto>> CreateAsync(CreateUserDto createUserDto);
        Task<GenericServiceResult<bool>> UpdateAsync(UpdateUserDto updateUserDto);
        Task<GenericServiceResult<IEnumerable<UserDto>>> GetAllAsync();
        Task<GenericServiceResult<IEnumerable<UserDto>>> GetByReferenceAsync(string userName);
        Task<GenericServiceResult<UserDto>> GetByUserIdAsync(long userId);
        Task<GenericServiceResult<UserDto>> GetByUsernameAsync(string userName);
        Task<GenericServiceResult<bool>> DeleteAsync(long userId);
    }
}
