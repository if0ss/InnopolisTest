using AutoMapper;
using Test.Application.Products.Commands.Update;
using Test.Application.Products.Dto;
using Test.Domain;

namespace Test.Application
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Product, UpdateProduct>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id));
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}