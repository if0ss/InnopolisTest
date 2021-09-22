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
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}