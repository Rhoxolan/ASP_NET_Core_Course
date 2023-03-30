using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.UserDTOs;

namespace OnlineShop.AutoMapperProfiles.UserProfiles
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile() => CreateMap<User, CreateUserDTO>()
            .ForMember(userDto => userDto.Login, opt => opt.MapFrom(user => user.UserName))
            .ReverseMap();
    }
}
