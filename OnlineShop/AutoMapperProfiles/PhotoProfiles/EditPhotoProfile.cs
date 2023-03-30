using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.PhotoDTOs;

namespace OnlineShop.AutoMapperProfiles.PhotoProfiles
{
    public class EditPhotoProfile : Profile
    {
        public EditPhotoProfile() => CreateMap<Photo, EditPhotoDTO>().ReverseMap();
    }
}
