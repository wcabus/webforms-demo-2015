using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Munchies.Data.Repositories
{
    public interface IAsyncReaderRepository<T> where T : class, new()
    {
        Task<IQueryable<T>> GetAsync();
        Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> whereExpression);
        Task<IQueryable<TSelect>> GetAsync<TSelect>(Expression<Func<T, TSelect>> selectExpression);
        Task<IQueryable<TSelect>> GetAsync<TSelect>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, TSelect>> selectExpression); 
    }
}