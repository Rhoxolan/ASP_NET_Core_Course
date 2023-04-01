using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.ViewModels.RolesViewModels;

namespace OnlineShop.AutoMapperProfiles.RoleProfiles
{
	public class ChangeRoleProfile : Profile
	{
		public ChangeRoleProfile() => CreateMap<User, ChangeRoleViewModel>()
			.ForMember(dest => dest.AllRoles, opt => opt.Ignore())
			.ForMember(dest => dest.UserRoles, opt => opt.Ignore());
	}
}
