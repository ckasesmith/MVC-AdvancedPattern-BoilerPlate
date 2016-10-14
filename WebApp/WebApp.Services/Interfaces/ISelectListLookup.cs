namespace WebApp.Services.Interfaces
{
    public interface ISelectListLookup <TViewModel>
    {
        /// <summary>
        /// This will ensure that you implement code to push the Select List into the view model for the UI to use
        /// </summary>
        TViewModel SetupSelectList(TViewModel viewModel);
    }
}
