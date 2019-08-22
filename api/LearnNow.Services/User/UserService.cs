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
            if (Context.Users.Any(u => u.UserName == createUserDto.UserName))
            {
                return GetFailedResult<UserDto>(new ErrorMessage("User Already Exists"));
            }

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

        public async Task<GenericServiceResult<bool>> DeleteAsync(long userId)
        {
            var userToDelete = await GetUserEntity(userId);

            if (userToDelete != null)
            {
                Context.Users.Remove(userToDelete);
                await Context.SaveChangesAsync();

                return GetSuccessResult(true);
            }

            return GetFailedResult<bool>(new ErrorMessage("Error Deleting User"));
        }

        public async Task<GenericServiceResult<IEnumerable<UserDto>>> GetAllAsync()
        {
            await Task.Yield();
            var users = Context.Users;
            return GetSuccessResult(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        public async Task<GenericServiceResult<UserDto>> GetByUserIdAsync(long userId)
        {
            var user = await GetUserEntity(userId);

            return GetSuccessResult(_mapper.Map<UserDto>(user));
        }

        public async Task<GenericServiceResult<UserDto>> GetByUsernameAsync(string userName)
        {
            var user = await Context
                .Users
                .SingleOrDefaultAsync(u => u.UserName == userName);

            return GetSuccessResult(_mapper.Map<UserDto>(user));
        }

        public async Task<GenericServiceResult<IEnumerable<UserDto>>> GetByReferenceAsync(string userName)
        {
            var user = await Context
                .Users
                .Where(u => u.UserName.Contains(userName))
                .OrderBy(u => u.UserName)
                .ToListAsync();

            return GetSuccessResult(_mapper.Map<IEnumerable<UserDto>>(user));
        }

        public async Task<GenericServiceResult<bool>> UpdateAsync(UpdateUserDto updateUserDto)
        {
            var user = await GetUserEntity(updateUserDto.Id);

            if (user != null)
            {
                user.Password = updateUserDto.Password;
                GetSuccessResult(true);
            }

            return GetFailedResult<bool>(new ErrorMessage("Error Updating User"));
        }

        private async Task<UserEntity> GetUserEntity (long userId)
        {
            return await Context
                .Users
                .SingleOrDefaultAsync (u => u.Id == userId);
        }
    }
}
