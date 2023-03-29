using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.ProductDTOs;

namespace OnlineShop.AutoMapperProfiles.ProductProfiles
{
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile() => CreateMap<Product, CreateProductDTO>().ReverseMap();
    }
}
