using AutoMapper;
using LearnNow.Contracts.User;
using LearnNow.Domain.Entities;

namespace LearnNow.Services
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            UserMappings();
        }

        public void UserMappings()
        {
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();
        }
    }
}
