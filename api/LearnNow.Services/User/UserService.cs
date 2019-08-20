using LearnNow.Contracts.User;
using LearnNow.Domain;
using LearnNow.Domain.Entities;
using LearnNow.Services.Abstract;
using LearnNow.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearnNow.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LearnNow.Services.User
{
    public class UserService : AbstractService, IUserService
    {
        private readonly IMapper _mapper;
        public UserService(LearnNowDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<GenericServiceResult<UserDto>> CreateAsync(CreateUserDto createUserDto)
        {
            var createdUser = Context.Users.Add(new UserEntity
            {
                UserName = createUserDto.UserName,
                Password = createUserDto.Password
            });

            if (await Context.SaveChangesAsync() > 0)
            {
                return GetSuccessResult(_mapper.Map<UserDto>(createdUser.Entity));
            }

            return GetFailedResult<UserDto>(new ErrorMessage
            {
                Message = "Error Creating User"
            });
        }

        public async Task<GenericServiceResult<IEnumerable<UserDto>>> GetAllAsync()
        {
            await Task.Yield();
            var users = Context.Users;
            return GetSuccessResult(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        public async Task<GenericServiceResult<UserDto>> GetByUsernameAsync(string userName)
        {
            var user = await Context
                .Users
                .SingleOrDefaultAsync(u => u.UserName == userName);

            return GetSuccessResult(_mapper.Map<UserDto>(user));
        }
    }
}
