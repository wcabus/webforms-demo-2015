using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Munchies.Data.Repositories
{
    public interface IAsyncReaderRepository<T> where T : class, new()
    {
        Task<List<T>> GetAsync(Expression<Func<T, bool>> where = null);
        Task<List<T>> GetOrderedAsync<TKey>(Expression<Func<T, bool>> where = null, Expression<Func<T, TKey>> orderBy = null);
        Task<List<TSelect>> GetAsync<TSelect>(Expression<Func<T, TSelect>> select, Expression<Func<T, bool>> where = null);
        Task<List<TSelect>> GetOrderedAsync<TSelect, TKey>(Expression<Func<T, TSelect>> select, Expression<Func<T, bool>> where = null, Expression<Func<TSelect, TKey>> orderBy = null);
    }
}