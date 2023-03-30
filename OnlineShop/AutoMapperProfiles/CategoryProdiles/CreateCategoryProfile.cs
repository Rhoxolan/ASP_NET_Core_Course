using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.CategoryDTOs;

namespace OnlineShop.AutoMapperProfiles.CategoryProdiles
{
    public class CreateCategoryProfile : Profile
    {
        public CreateCategoryProfile() => CreateMap<Category, CreateCategoryDTO>().ReverseMap();
    }
}
