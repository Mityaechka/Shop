using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService,IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }
        [Route("")]
        [HttpGet]
        public async Task<ApiResult<List<ProductViewModel>>> GetProducts()
        {
            return _mapper.MapApi<List<ProductViewModel>, List<Product>>(new List<Product>());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ApiResult<ProductViewModel>> GetProduct(int id)
        {
            return _mapper.MapApi<ProductViewModel, Product>(new Product());
        }

    }
}
