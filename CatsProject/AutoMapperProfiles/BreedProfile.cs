using AutoMapper;
using BigProject.Data.Entities;
using BigProject.Models.DTO;

namespace CatsProject.AutoMapperProfiles
{
	public class BreedProfile : Profile
	{
		public BreedProfile()
		{
			CreateMap<Breed, BreedDTO>().ReverseMap();
		}
	}
}
