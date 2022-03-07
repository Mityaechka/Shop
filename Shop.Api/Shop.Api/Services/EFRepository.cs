using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Shop.Api.Services
{

    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly ShopContext _shopContext;

        public EFRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;

        }

        public DbSet<T> All => _shopContext.Set<T>();

        public void Add(T data)
        {
            _shopContext.Add(data);
        }

        public async Task SaveAsync()
        {
            await _shopContext.SaveChangesAsync();
        }
    }
}
