using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Model.DTO;
using Wheelzy.Model.Entites;

namespace Wheelzy.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductGrid>();
            CreateMap<ProductDto, Product>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
        
    }
}
