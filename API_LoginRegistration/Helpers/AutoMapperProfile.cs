using AutoMapper;
using API_LoginRegistration.Dtos;
using API_LoginRegistration.Entities;

namespace API_LoginRegistration.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}