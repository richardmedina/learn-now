using AutoMapper;
using LearnNow.Contracts.User;
using LearnNow.Domain.Entities;

namespace LearnNow.Services
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateUserMappings();
        }

        public void CreateUserMappings()
        {
            CreateMap<UserDto, UserEntity>();
        }
    }
}
