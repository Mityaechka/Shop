using AutoMapper;
using Shop.Api.Models;

namespace Shop.Api.Extensions
{
    public static class MapperExtensions
    {
        public static ApiResult<TTo> MapApi<TTo, TFrom>(this IMapper mapper, TFrom data)
        {
            return new ApiResult<TTo> { IsError = false, Data = mapper.Map<TTo>(data) };
        }
    }
}
