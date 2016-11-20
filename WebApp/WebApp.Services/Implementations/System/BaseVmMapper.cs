using System.Collections.Generic;
using AutoMapper;

namespace WebApp.Services.Implementations.System
{
    public class BaseVmMapper<TViewModel, TModel>
    {

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