using AutoMapper;
using LearnNow.Api.Models.Auth;
using LearnNow.Api.Models.Users;
using LearnNow.Contracts.Auth;
using LearnNow.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnNow.Api.Mappings
{
    public class ModelMappings : Profile
    {
        public ModelMappings()
        {
            CreateUserMappings();
            CreateAuthMappings();
        }

        public void CreateUserMappings ()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

            CreateMap<CreateUserRequestModel, CreateUserDto>();
            CreateMap<UpdateUserRequestModel, UpdateUserDto>();
        }

        public void CreateAuthMappings ()
        {
            CreateMap<AuthRequestModel, AuthorizeDto>();
        }
    }
}
