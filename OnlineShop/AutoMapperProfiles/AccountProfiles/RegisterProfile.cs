using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.ViewModels.AccountViewModels;

namespace OnlineShop.AutoMapperProfiles.AccountProfiles
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile() => CreateMap<User, RegisterViewModel>().ReverseMap();
    }
}
