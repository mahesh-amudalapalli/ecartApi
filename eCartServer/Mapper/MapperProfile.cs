using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCartDtos;
using eCartContracts.BusinessModels;

namespace eCartServer.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductModel, ProductDto>().ReverseMap();

            CreateMap<CategoryModel, CategoryDto>().ReverseMap();
        }
    }
}
