using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Data;
using OnlineShop.Models.ViewModels.RolesViewModels;

namespace OnlineShop.AutoMapperProfiles.RoleProfiles
{
	public class ChangeRoleProfile : Profile
	{
		public ChangeRoleProfile() => CreateMap<User, ChangeRoleViewModel>();
	}
}
