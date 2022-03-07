using AutoMapper;
using Shop.Api.Data;
using Shop.Api.DTO;

namespace Shop.Api.Infrastructure
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<Product, ProductViewModel>().ForMember(x => x.ImagePath, options => options.MapFrom(x => x.Image == null ? null : x.Image.Path));

            CreateMap<Order, OrderWithProductsViewModel>();
            CreateMap<Order, OrderWithProductsAndLogsViewModel>();
            CreateMap<Order, OrderViewModel>();

            CreateMap<OrderProduct, OrderProductViewModel>();

            CreateMap<Log, LogViewModel>();
            CreateMap<OrderLog, LogViewModel>()
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Log.Id))
                .ForMember(x => x.Level, options => options.MapFrom(x => x.Log.Level))
                .ForMember(x => x.Message, options => options.MapFrom(x => x.Log.Message));

        }
    }
}
