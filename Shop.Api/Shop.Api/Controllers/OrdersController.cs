using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Data;
using Shop.Api.DTO;
using Shop.Api.Extensions;
using Shop.Api.Models;
using Shop.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersService ordersService, IMapper mapper)
        {
            _ordersService = ordersService;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        public async Task<ApiResult<List<OrderViewModel>>> GetOrders()
        {
            var orders = await _ordersService.GetOrders();
            return _mapper.MapApi<List<OrderViewModel>, List<Order>>(orders);
        }

        [Route("{orderId}")]
        [HttpGet]
        public async Task<ApiResult<OrderWithProductsAndLogsViewModel>> GetOrder(int orderId)
        {
            var order = await _ordersService.GetOrder(orderId);

            if (order == null)
            {
                return ApiResult<OrderWithProductsAndLogsViewModel>.Error();
            }

            return _mapper.MapApi<OrderWithProductsAndLogsViewModel, Order>(order);
        }

        [HttpGet]
        [Route("form-order")]
        public async Task<ApiResult<OrderWithProductsViewModel>> GetFormOrder()
        {
            var hasFormOrder = await _ordersService.HasAnyFormOrder();

            if (!hasFormOrder)
            {
                return new ApiResult<OrderWithProductsViewModel> { IsError = false, Data = null };
            }

            var order = await _ordersService.GetFormOrder();

            return _mapper.MapApi<OrderWithProductsViewModel, Order>(order);
        }

        [HttpPost]
        [Route("add-order")]
        public async Task<ApiResult> AddOrder()
        {
            var result = await _ordersService.AddOrder();

            if (result == null)
            {
                return ApiResult.Error();
            }

            return ApiResult.Success();
        }

        [Route("form-order/add/{productId}")]
        [HttpPost]
        public async Task<ApiResult> AddProductToFormOrder(int productId)
        {
            var result = await _ordersService.TryAddProductToFormOrder(productId);

            if (!result)
            {
                return ApiResult.Error();
            }

            return ApiResult.Success();
        }

        [Route("form-order/remove/{productId}")]
        [HttpPost]
        public async Task<ApiResult> RemoveProductFromOrder(int productId)
        {
            var result = await _ordersService.TryRemoveProductFromFormOrder(productId);

            if (!result)
            {
                return ApiResult.Error();
            }

            return ApiResult.Success();
        }

        [Route("form-order/pay")]
        [HttpPost]
        public async Task<ApiResult> PayOrder(OrderInformationCreateViewModel orderInformation)
        {
            var result = await _ordersService.SetFormOrderStatePay(orderInformation);

            if (!result)
            {
                return ApiResult.Error();
            }

            return ApiResult.Success();
        }

        [Route("{orderId}/complete")]
        [HttpPost]
        public async Task<ApiResult> CompleterOrder(int orderId)
        {
            var result = await _ordersService.SetOrderStateConfirm(orderId);

            if (!result)
            {
                return ApiResult.Error();
            }

            return ApiResult.Success();
        }
    }
}
