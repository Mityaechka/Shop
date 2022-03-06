using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Data;
using Shop.Api.DTO;
using Shop.Api.Extensions;
using Shop.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [Route("")]
        [HttpGet]
        public async Task<ApiResult<List<OrderViewModel>>> GetOrders()
        {
            return _mapper.MapApi<List<OrderViewModel>, List<Product>>(new List<Product>());
        }

        [Route("{orderId}")]
        [HttpGet]
        public async Task<ApiResult<OrderViewModel>> GetOrder(int orderId)
        {
            return _mapper.MapApi<OrderViewModel, Order>(new Order());
        }

        [Route("{orderId}/add/{productId}")]
        [HttpPost]
        public async Task<ApiResult> AddProductToOrder(int orderId, int productId)
        {
            return null;
        }

        [Route("{orderId}/remove/{productId}")]
        [HttpPost]
        public async Task<ApiResult> RemoveProductFromOrder(int orderId, int productId)
        {
            return null;
        }

        [Route("{orderId}/pay")]
        [HttpPost]
        public async Task<ApiResult> PayOrder(int orderId, OrderInformationCreateViewModel orderInformation)
        {
            return null;
        }

        [Route("{orderId}/complete")]
        [HttpPost]
        public async Task<ApiResult> CompleterOrder(int orderId)
        {
            return null;
        }
    }
}
