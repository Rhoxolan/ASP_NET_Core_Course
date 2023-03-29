using AutoMapper;
using OnlineShop.Data;
using OnlineShop.Models.DTO.CategoryDTOs;

namespace OnlineShop.AutoMapperProfiles.CategoryProdiles
{
    public class EditCategoryProfile : Profile
    {
        public EditCategoryProfile() => CreateMap<Category, EditCategoryDTO>().ReverseMap();
    }
}
