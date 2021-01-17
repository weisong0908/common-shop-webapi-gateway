using AutoMapper;
using CommonShop.WebApiGateway.Models;
using CommonShop.WebApiGateway.Models.Responses;

namespace CommonShop.WebApiGateway.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, SimpleOrder>();
            CreateMap<Order, SimpleOrderForAdmin>()
                .ForMember(s => s.OrderStatus, memberOptions => memberOptions.MapFrom(o => ((OrderStatus)o.OrderStatus).ToString()));
            CreateMap<Order, DetailedOrder>()
                .ForMember(d => d.Products, memberOptions => memberOptions.MapFrom(o => o.OrderProducts))
                .ForMember(s => s.OrderStatus, memberOptions => memberOptions.MapFrom(o => ((OrderStatus)o.OrderStatus).ToString()));

            CreateMap<OrderProduct, OrderItem>()
                .ForMember(oi => oi.Id, memberOptions => memberOptions.MapFrom(op => op.Product.Id))
                .ForMember(oi => oi.Title, memberOptions => memberOptions.MapFrom(op => op.Product.Title))
                .ForMember(oi => oi.Price, memberOptions => memberOptions.MapFrom(op => op.Product.Price));
        }
    }
}