using LearnNow.Contracts.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnNow.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(CreateUserDto createUserDto);
    }
}
