using System.Collections.Generic;
using System.Linq;
using WebApp.Repositories.Interfaces;
using WebApp.Services.Interfaces.System;

namespace WebApp.Services.Implementations.System
{
    public abstract class BaseService<TModel, TKey> : ICrud<TModel, TKey> where TModel : new()
    {
        public IRepository<TModel, TKey> Repository;

        protected BaseService(IRepository<TModel, TKey> repository)
        {
            Repository = repository;
        }        

        public virtual List<TModel> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public virtual TModel DetailsGet(TKey id)
        {
            return Repository.Find(id);
        }

        public virtual TModel CreateGet()
        {
            return new TModel();
        }

        public virtual TModel CreatePost(TModel model)
        {
            Repository.Add(model);
            Repository.SaveChanges();
            return model;
        }

        public virtual TModel CreatePostFailed(TModel model)
        {
            return model;
        }

        public virtual TModel EditGet(TKey id)
        {
            var result = Repository.Find(id);
            return result;
        }

        public virtual TModel EditPost(TModel model, TKey key)
        {
            Repository.Update( model);
            Repository.SaveChanges();
            return model;
        }

        public virtual TModel EditPostFailed(TModel model)
        {
            return model;
        }

        public virtual TModel DeleteGet(TKey id)
        {
            return EditGet(id);
        }

        public virtual void DeletePost(TKey key)
        {
            Repository.Remove(key);
            Repository.SaveChanges();
        }


    }
}
