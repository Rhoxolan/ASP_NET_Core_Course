using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.UserDTOs;

namespace OnlineShop.AutoMapperProfiles.UserProfiles
{
    public class EditUserProfile : Profile
    {
        public EditUserProfile() => CreateMap<User, EditUserDTO>()
            .ForMember(userDto => userDto.Login, opt => opt.MapFrom(user => user.UserName))
            .ReverseMap();
    }
}
