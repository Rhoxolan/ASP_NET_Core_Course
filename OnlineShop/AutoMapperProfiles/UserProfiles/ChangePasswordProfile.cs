using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.UserDTOs;

namespace OnlineShop.AutoMapperProfiles.UserProfiles
{
    public class ChangePasswordProfile : Profile
    {
        public ChangePasswordProfile() => CreateMap<User, ChangePasswordDTO>();
    }
}
