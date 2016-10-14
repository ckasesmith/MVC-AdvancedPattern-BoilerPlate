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
            _dataContext.Configuration.AutoDetectChangesEnabled = false;
            DBset = Set();

        }
        public IQueryable<T> GetAll()
        {
            return GetQuery().AsNoTracking();
        }


        public IQueryable<T> Where(Expression<Func<T, bool>> expression, int maxHits = 0)
        {
            if (maxHits == 0)
            {
                return GetQuery().AsNoTracking().Where(expression);
            }
            return GetQuery().AsNoTracking().Where(expression).Take(100);
        }
        public IQueryable<T> WhereNoTrack(Expression<Func<T, bool>> expression, int maxHits = 0)
        {
            if (maxHits == 0)
            {
                return GetQuery().AsNoTracking().Where(expression);
            }
            return GetQuery().AsNoTracking().Where(expression).Take(100);
        }


        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return GetQuery().AsNoTracking().FirstOrDefault(expression);
        }

        public T FirstOrDefaultNoTrack(Expression<Func<T, bool>> expression)
        {
            return GetQuery().AsNoTracking().FirstOrDefault(expression);
        }

        public IQueryable<T> Page(int page = 0, int pageSize = 10)
        {
            return GetQuery().AsNoTracking().Skip(page * pageSize).Take(pageSize);
        }


        public virtual int Count(Expression<Func<T, bool>> expression)
        {
            return DBset.AsNoTracking().Count(expression);
        }

        public void Add(T entity)
        {
            DBset.Add(entity);
        }

        public void Update(TKey key, T entity)
        {
            var savedrecord = DBset.Find(key);
            _dataContext.Entry(savedrecord).CurrentValues.SetValues(entity);

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
            return DBset.AsNoTracking().Any(expression);
        }

        public void UpdateAll(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                var entry = _dataContext.Entry(entity);
                DBset.Attach(entity);
                entry.State = EntityState.Modified;

            }
            _dataContext.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return _dataContext.Set<T>();
        }

        private IQueryable<T> GetQuery()
        {
            return DBset.AsNoTracking();
        }

        public void Dispose()
        {

            //_dataContext.Dispose();

        }


    }
}
