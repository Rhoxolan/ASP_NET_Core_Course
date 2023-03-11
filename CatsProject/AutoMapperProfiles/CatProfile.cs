using AutoMapper;
using BigProject.Data.Entities;
using BigProject.Models.DTO;

namespace CatsProject.AutoMapperProfiles
{
	public class CatProfile : Profile
	{
		public CatProfile()
		{
			CreateMap<Cat, CatDTO>().ReverseMap();
		}
	}
}
