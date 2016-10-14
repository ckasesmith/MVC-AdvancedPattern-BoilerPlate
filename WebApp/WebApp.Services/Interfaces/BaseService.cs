using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApp.Repositories.Interfaces;

namespace WebApp.Services.Interfaces
{
    public abstract class BaseService<TViewModel, TModel, TKey> : ICrud<TViewModel, TKey>, IViewModel<TViewModel, TModel> where TViewModel : new()
    {
        public IRepository<TModel, TKey> Repository;

        protected BaseService(IRepository<TModel, TKey> repository)
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

        public virtual TViewModel EditPost(TViewModel viewModel, TKey key)
        {
            Repository.Update(key, Map(viewModel));
            Repository.SaveChanges();
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

        public virtual TModel Map(TViewModel viewModel)
        {
            return Mapper.Map<TModel>(viewModel);
        }

        public virtual TViewModel Map(TModel model)
        {
            return Mapper.Map<TViewModel>(model);
        }

        public virtual List<TModel> Map(List<TViewModel> viewModels)
        {
            return Mapper.Map<List<TModel>>(viewModels);
        }

        public virtual List<TViewModel> Map(List<TModel> models)
        {
            return Mapper.Map<List<TViewModel>>(models);
        }
    }
}
