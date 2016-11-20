using System.Collections.Generic;

namespace WebApp.Services.Interfaces.System
{
    /// <summary>
    /// Defines the requirements of all View Models
    /// </summary>
    /// <typeparam name="TModel">The Model that connects to this view model</typeparam>
    /// <typeparam name="TViewModel">The View Model</typeparam>
    public interface IViewModelMapper<TViewModel, TModel>
    {
        TModel Map(TViewModel viewModel);
        TViewModel Map(TModel model);
        List<TModel> Map(List<TViewModel> viewModels);
        List<TViewModel> Map(List<TModel> models);
    }
}
