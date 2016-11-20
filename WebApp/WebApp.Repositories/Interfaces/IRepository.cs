using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApp.Repositories.Interfaces
{
    public interface IRepository<T, in TKey> : IDisposable
    {
        IQueryable<T> GetAll();


        IQueryable<T> Where(Expression<Func<T, bool>> expression, int maxHits = 0);
        /// <summary>
        /// Does not keep track of changes to the returned items
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="maxHits"></param>
        /// <returns></returns>
        IQueryable<T> WhereNoTrack(Expression<Func<T, bool>> expression, int maxHits = 0);

        T FirstOrDefault(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Does not keep track of changes to the returned item
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T FirstOrDefaultNoTrack(Expression<Func<T, bool>> expression);

        IQueryable<T> Page(int page = 1, int pageSize = 10);

        int Count(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);
        void Remove(TKey key);
        T Find(TKey id);

        int SaveChanges();
        bool Any(Expression<Func<T, bool>> expression);
    }
}
