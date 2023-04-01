using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.ProductDTOs;

namespace OnlineShop.AutoMapperProfiles.ProductProfiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile() => CreateMap<Product, ProductDTO>();
	}
}
