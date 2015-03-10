using Munchies.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Munchies.Data.EF
{
    public class Repository<T> : IAsyncReaderRepository<T> 
        where T : class, new()
    {
        private readonly MunchiesDbContext _context;

        public Repository(MunchiesDbContext context)
	    {
            _context = context;
	    }

        //public List<T> Get() {
        //    return _context.Set<T>().ToList();
        //}

        //public List<T> Get(Expression<Func<T, bool>> whereExpression)
        //{
        //    return _context.Set<T>().Where(whereExpression).ToList();
        //}

        //public List<TSelect> Get<TSelect>(Expression<Func<T, TSelect>> selectExpression)
        //{
        //    return _context.Set<T>().Select(selectExpression).ToList();
        //}

        //public List<TSelect> Get<TSelect>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, TSelect>> selectExpression)
        //{
        //    return _context.Set<T>().Where(whereExpression).Select(selectExpression).ToList();
        //}

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (where != null)
                query = query.Where(where);

            return query.ToListAsync();
        }

        public Task<List<T>> GetOrderedAsync<TKey>(Expression<Func<T, bool>> where = null, Expression<Func<T, TKey>> orderBy = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (where != null)
                query = query.Where(where);

            if (orderBy != null)
                query = query.OrderBy(orderBy);

            return query.ToListAsync();
        }

        public Task<List<TSelect>> GetAsync<TSelect>(Expression<Func<T, TSelect>> select, Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (where != null)
                query = query.Where(where);

            IQueryable<TSelect> query2 = query.Select(select);
            return query2.ToListAsync();
        }

        public Task<List<TSelect>> GetOrderedAsync<TSelect, TKey>(Expression<Func<T, TSelect>> select, Expression<Func<T, bool>> where = null, Expression<Func<TSelect, TKey>> orderBy = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (where != null)
                query = query.Where(where);

            IQueryable<TSelect> query2 = query.Select(select);

            if (orderBy != null)
                query2 = query2.OrderBy(orderBy);

            return query2.ToListAsync();

        }


    }
}
