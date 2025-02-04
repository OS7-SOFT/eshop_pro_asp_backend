using AutoMapper;
using EShopPro.Application.Features.Categories.DTOs;
using EShopPro.Domain.Entities;


namespace CleanArchitectureAPI.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
