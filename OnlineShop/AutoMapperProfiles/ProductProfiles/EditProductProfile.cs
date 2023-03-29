using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.ProductDTOs;

namespace OnlineShop.AutoMapperProfiles.ProductProfiles
{
    public class EditProductProfile : Profile
    {
        public EditProductProfile() => CreateMap<Product, EditProductDTO>().ReverseMap();
    }
}
