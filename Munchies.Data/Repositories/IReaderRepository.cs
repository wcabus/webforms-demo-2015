using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Munchies.Data.Repositories
{
    public interface IReaderRepository<T> where T : class, new()
    {
        List<T> Get();
        List<T> Get(Expression<Func<T, bool>> whereExpression);
        List<TSelect> Get<TSelect>(Expression<Func<T, TSelect>> selectExpression);
        List<TSelect> Get<TSelect>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, TSelect>> selectExpression);
    }
}