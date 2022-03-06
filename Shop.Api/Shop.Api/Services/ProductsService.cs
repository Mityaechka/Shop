using Microsoft.EntityFrameworkCore;
using Shop.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Services
{
    public interface IProductsService
    {
        Task<Product> GetProduct(int productId);
        Task<List<Product>> GetProducts();
    }

    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductsService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.All.ToListAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await _productRepository.All.FirstOrDefaultAsync(x => x.Id == productId);
        }
    }
}
