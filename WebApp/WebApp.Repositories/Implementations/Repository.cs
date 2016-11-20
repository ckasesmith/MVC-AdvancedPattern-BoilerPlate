using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TrackerEnabledDbContext.Identity;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Repositories.Implementations
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly TrackerIdentityContext<ApplicationUser> _dataContext;
        public IDbSet<T> DBset;

        public Repository(TrackerIdentityContext<ApplicationUser> newDbContext)
        {
            _dataContext = newDbContext;
            DBset = Set();
        }

        public IQueryable<T> GetAll()
        {
            return GetQuery();
        }


        public IQueryable<T> Where(Expression<Func<T, bool>> expression, int maxHits = 0)
        {
            if (maxHits == 0)
            {
                return GetQuery().Where(expression);
            }
            return GetQuery().Where(expression).Take(100);
        }
        public IQueryable<T> WhereNoTrack(Expression<Func<T, bool>> expression, int maxHits = 0)
        {
            if (maxHits == 0)
            {
                return GetQuery().Where(expression);
            }
            return GetQuery().Where(expression).Take(100);
        }


        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return GetQuery().FirstOrDefault(expression);
        }

        public T FirstOrDefaultNoTrack(Expression<Func<T, bool>> expression)
        {
            return GetQuery().FirstOrDefault(expression);
        }

        public IQueryable<T> Page(int page = 0, int pageSize = 10)
        {
            return GetQuery().Skip(page * pageSize).Take(pageSize);
        }


        public virtual int Count(Expression<Func<T, bool>> expression)
        {
            return DBset.Count(expression);
        }

        public void Add(T entity)
        {
            DBset.Add(entity);
        }

        public void Update(T entity)
        {
            var status = _dataContext.Entry(entity).State;
            if (status == EntityState.Detached)
            {
                _dataContext.Set<T>().Attach(entity);
            }
            _dataContext.Entry(entity).State = EntityState.Modified;

        }


        public void Remove(T entity)
        {

            DBset.Remove(entity);

        }

        public void Remove(TKey key)
        {
            var savedrecord = Find(key);
            DBset.Remove(savedrecord);

        }

        public T Find(TKey id)
        {
            return DBset.Find(id);
        }



        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return DBset.Any(expression);
        }

        public void UpdateAll(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                var status = _dataContext.Entry(entity).State;
                if (status == EntityState.Detached)
                {
                    _dataContext.Set<T>().Attach(entity);
                }
                _dataContext.Entry(entity).State = EntityState.Modified;

            }
            _dataContext.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return _dataContext.Set<T>();
        }

        private IQueryable<T> GetQuery()
        {
            return DBset;
        }

        public void Dispose()
        {//_dataContext.Dispose();
        }


    }
}
