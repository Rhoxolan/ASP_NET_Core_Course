using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.PhotoDTOs;

namespace OnlineShop.AutoMapperProfiles.PhotoProfiles
{
    public class CreatePhotoProfile : Profile
    {
        public CreatePhotoProfile() => CreateMap<Photo, CreatePhotoDTO>().ReverseMap();
    }
}
