using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Shop.Api.Services
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> All { get; }

        void Add(T data);
        Task SaveAsync();
    }
}