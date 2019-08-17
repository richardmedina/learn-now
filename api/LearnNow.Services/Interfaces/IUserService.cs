using LearnNow.Contracts.User;
using System.Threading.Tasks;

namespace LearnNow.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDto createUserDto);
    }
}
