using LearnNow.Contracts.User;
using LearnNow.Domain;
using LearnNow.Services.Abstract;
using LearnNow.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnNow.Services.User
{
    public class UserService : AbstractService, IUserService
    {
        public UserService(LearnNowDbContext context) : base(context)
        {
        }

        public Task CreateAsync(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
