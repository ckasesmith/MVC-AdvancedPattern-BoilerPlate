using System.Collections.Generic;

namespace WebApp.Services.Interfaces
{
    /// <summary>
    /// CRUD Operations | Create Read Update Delete
    /// </summary>
    public interface ICrud<TViewModel, TKey>
    {
        IList<TViewModel> Index();
        TViewModel DetailsGet(TKey id);

        TViewModel CreateGet();
        TViewModel CreatePost(TViewModel viewModel);
        TViewModel CreatePostFailed(TViewModel viewModel);

        TViewModel EditGet(TKey id);
        TViewModel EditPost(TViewModel viewModel, TKey key);


        TViewModel DeleteGet(TKey id);
        void DeletePost(TKey key);

    }
}
