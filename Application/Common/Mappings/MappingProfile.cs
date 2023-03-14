
using Application.Features.Orders.Query.GetAllOrdersByUserId;
using Application.Features.Products.ProductBrands.Command.CreateProductBrand;
using Application.Features.Products.ProductBrands.Command.UpdateProductBrand;
using Application.Features.Products.ProductTypes.Command.CreateProductType;
using Application.Features.Products.ProductTypes.Command.UpdateProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductBrandCommand, ProductBrand>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.BrandName))
                .ReverseMap();

            CreateMap<UpdateProductBrandCommand, ProductBrand>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.BrandName))
                .ReverseMap();

            CreateMap<CreateProductTypeCommand, ProductType>()
                .ReverseMap();

            CreateMap<UpdateProductTypeCommand, ProductType>()
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pending"));
        }
    }
}
