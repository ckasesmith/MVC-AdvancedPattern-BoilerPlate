using System.Collections.Generic;
using System.Linq;
using WebApp.Repositories.Interfaces;
using WebApp.Services.Interfaces.System;

namespace WebApp.Services.Implementations.System
{
    public abstract class BaseVmService<TViewModel, TModel, TKey> : BaseVmMapper<TViewModel, TModel>, ICrudViewModel<TViewModel, TModel, TKey> where TViewModel : new()
    {
        public IRepository<TModel, TKey> Repository;


        protected BaseVmService(IRepository<TModel, TKey> repository)
        {
            Repository = repository;
        }

        public virtual IList<TViewModel> Index()
        {
            return Map(Repository.GetAll().ToList());
        }

        public virtual TViewModel DetailsGet(TKey id)
        {
            return Map(Repository.Find(id));
        }

        public virtual TViewModel CreateGet()
        {
            return new TViewModel();
        }

        public virtual TViewModel CreatePost(TViewModel viewModel)
        {
            Repository.Add(Map(viewModel));
            Repository.SaveChanges();
            return viewModel;
        }

        public virtual TViewModel CreatePostFailed(TViewModel viewModel)
        {
            return viewModel;
        }

        public virtual TViewModel EditGet(TKey id)
        {
            var result = Repository.Find(id);
            return Map(result);
        }

        public virtual TViewModel EditPost(TViewModel viewModel)
        {
            Repository.Update( Map(viewModel));
            Repository.SaveChanges();
            return viewModel;
        }

        public virtual TViewModel EditPostFailed(TViewModel viewModel)
        {
            return viewModel;
        }

        public virtual TViewModel DeleteGet(TKey id)
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
