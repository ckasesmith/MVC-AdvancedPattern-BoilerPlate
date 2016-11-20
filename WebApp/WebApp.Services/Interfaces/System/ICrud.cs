using System.Collections.Generic;

namespace WebApp.Services.Interfaces.System
{
    /// <summary>
    /// CRUD Operations | Create Read Update Delete
    /// </summary>
    public interface ICrud<TModel, in TKey>
    {        
        List<TModel> GetAll();
        TModel DetailsGet(TKey id);

        TModel CreateGet();
        TModel CreatePost(TModel viewModel);
        TModel CreatePostFailed(TModel viewModel);

        TModel EditGet(TKey id);
        TModel EditPost(TModel viewModel, TKey key);
        TModel EditPostFailed(TModel viewModel);

        TModel DeleteGet(TKey id);
        void DeletePost(TKey key);

    }
}
