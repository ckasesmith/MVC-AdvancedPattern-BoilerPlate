namespace WebApp.Services.Interfaces.UserInfo
{
    public interface IAddressService<TViewModel, TModel, TKey> : ICrud<TViewModel, TKey>, IViewModel<TViewModel, TModel>,ISelectListLookup<TViewModel>
    {
        //This is here so that you can leverage the predetermined interfaces and expand your particular interface as needed.
        //This seems like a redundancy but it abstracts the functions of the concrete service and allow you to mock the custom code as needed.
    }
}
