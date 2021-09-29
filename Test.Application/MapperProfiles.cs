using System.Data;
using AutoMapper;
using Test.Application.Products.Commands.Add;
using Test.Application.Products.Commands.Update;
using Test.Application.Products.Dto;
using Test.Application.ProductStorehouses.Commands.Add;
using Test.Application.ProductStorehouses.Dto;
using Test.Application.Storehouses.Commands.Add;
using Test.Application.Storehouses.Commands.Update;
using Test.Application.Storehouses.Dto;
using Test.Domain;

namespace Test.Application
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Product, AddProduct>().ReverseMap();
            CreateMap<Product, UpdateProduct>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();

            CreateMap<Storehouse, AddStorehouse>().ReverseMap();
            CreateMap<Storehouse, UpdateStorehouse>().ReverseMap();
            CreateMap<Storehouse, StorehouseDto>().ReverseMap();
            CreateMap<Storehouse, StorehouseListDto>().ReverseMap();

            CreateMap<ProductStorehouse, AddProductStorehouse>().ReverseMap();
            CreateMap<ProductStorehouse, ProductStorehouseDto>().ReverseMap();
            CreateMap<ProductStorehouse, ProductStorehouseListDto>().ReverseMap();
        }
    }
}