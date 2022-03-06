using AutoMapper;
using Shop.Api.Data;
using Shop.Api.DTO;

namespace Shop.Api.Infrastructure
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            //CreateMap<Product, ProductViewModel>().ForMember(x => x.ImagePath, options => options.MapFrom(x => x.Image == null ? null : x.Image.Path));
        }
    }
}
