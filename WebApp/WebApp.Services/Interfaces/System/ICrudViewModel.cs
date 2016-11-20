using System.Collections.Generic;

namespace WebApp.Services.Interfaces.System
{
    /// <summary>
    /// CRUD Operations | Create Read Update Delete
    /// </summary>
    public interface ICrudViewModel<TViewModel,TModel , in TKey>:IViewModelMapper<TViewModel,TModel>
    {
        IList<TViewModel> Index();
        TViewModel DetailsGet(TKey id);

        TViewModel CreateGet();
        TViewModel CreatePost(TViewModel viewModel);
        TViewModel CreatePostFailed(TViewModel viewModel);

        TViewModel EditGet(TKey id);
        TViewModel EditPost(TViewModel viewModel);
        TViewModel EditPostFailed(TViewModel viewModel);

        TViewModel DeleteGet(TKey id);
        void DeletePost(TKey key);

    }
}
