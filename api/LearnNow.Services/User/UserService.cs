using LearnNow.Contracts.User;
using LearnNow.Domain;
using LearnNow.Domain.Entities;
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

        public async Task CreateAsync(CreateUserDto createUserDto)
        { 
            Context.Users.Add(new UserEntity
            {
                Username = createUserDto.UserName,
                Password = createUserDto.Password
            });

            await Context.SaveChangesAsync();
        }
    }
}
