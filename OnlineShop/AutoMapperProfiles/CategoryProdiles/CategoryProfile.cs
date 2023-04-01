using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.CategoryDTOs;

namespace OnlineShop.AutoMapperProfiles.CategoryProdiles
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile() => CreateMap<CategoryDTO, Category>().ReverseMap();
	}
}
