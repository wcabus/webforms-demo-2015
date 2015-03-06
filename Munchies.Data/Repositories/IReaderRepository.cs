using System;
using System.Linq;
using System.Linq.Expressions;

namespace Munchies.Data.Repositories
{
    public interface IReaderRepository<T> where T : class, new()
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> whereExpression);
        IQueryable<TSelect> Get<TSelect>(Expression<Func<T, TSelect>> selectExpression);
        IQueryable<TSelect> Get<TSelect>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, TSelect>> selectExpression);
    }
}