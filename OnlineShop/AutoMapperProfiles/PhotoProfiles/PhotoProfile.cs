using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.PhotoDTOs;

namespace OnlineShop.AutoMapperProfiles.PhotoProfiles
{
	public class PhotoProfile : Profile
	{
		public PhotoProfile() => CreateMap<Photo, PhotoDTO>();
	}
}
