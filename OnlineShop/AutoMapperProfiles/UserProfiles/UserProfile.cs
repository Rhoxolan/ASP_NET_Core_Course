using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.UserDTOs;

namespace OnlineShop.AutoMapperProfiles.UserProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() => CreateMap<User, UserDTO>()
            .ForMember(userDto => userDto.Login, opt => opt.MapFrom(user => user.UserName))
            .ReverseMap();
    }
}