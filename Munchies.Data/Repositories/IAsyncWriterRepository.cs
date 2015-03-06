using System.Threading.Tasks;

namespace Munchies.Data.Repositories
{
    public interface IAsyncWriterRepository<in T> where T : class, new()
    {
        Task SaveAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveChangesAsync(); 
    }
}