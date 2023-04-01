using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Models.DTO.RoleDTOs;

namespace OnlineShop.AutoMapperProfiles.RoleProfiles
{
	public class RoleProfile : Profile
	{
		public RoleProfile() => CreateMap<IdentityRole, RoleDTO>().ReverseMap();
	}
}
