using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApp.Models;
using WebApp.Repositories.Interfaces;
using WebApp.Services.Interfaces;
using WebApp.Services.Interfaces.UserInfo;
using WebApp.ViewModels;

namespace WebApp.Services.Implementations.UserInfo
{
    /// <summary>
    /// This class is derived from the base class which is closed to modifications,
    /// This class extends IAddressService which in tern extends the base class features
    /// This BaseClass is not a requirement for services, it just implements the default crud operations
    /// The Interface is the most important part of this, where it determines what features the service has
    /// </summary>
    public class AddressService : BaseService<AddressViewModel, Address, int>, IAddressService<AddressViewModel, Address, int>
    {
        private readonly IRepository<Country, int> _countryRepository;
        private readonly IRepository<StateParish, int> _stateParishRepository;
        public AddressService(IRepository<Address, int> repository, IRepository<Country, int> countryRepository, IRepository<StateParish, int> stateParishRepository) : base(repository)
        {
            _countryRepository = countryRepository;
            _stateParishRepository = stateParishRepository;
        }
        /// <summary>
        /// You can override the base class features as needed
        /// </summary>
        /// <returns></returns>
        public override IList<AddressViewModel> Index()
        {
            var result = Repository.GetAll().Include(x => x.Country).Include(x => x.StateParish).ToList();

            return Map(result);
        }

        public override AddressViewModel CreateGet()
        {
            return SetupSelectList(base.CreateGet());
        }

        public override AddressViewModel CreatePost(AddressViewModel viewModel)
        {
            viewModel.UserId = Thread.CurrentPrincipal.Identity.GetUserId();
            return base.CreatePost(viewModel);
        }

        public override AddressViewModel EditGet(int id)
        {
            return SetupSelectList(base.EditGet(id));
        }

        public override AddressViewModel EditPost(AddressViewModel viewModel, int key)
        {
            viewModel.UserId = Thread.CurrentPrincipal.Identity.GetUserId();
            return SetupSelectList(base.EditPost(viewModel, key));
        }

        public override AddressViewModel CreatePostFailed(AddressViewModel viewModel)
        {
            viewModel.UserId = Thread.CurrentPrincipal.Identity.GetUserId();
            return SetupSelectList(base.CreatePostFailed(viewModel));
        }

        public AddressViewModel SetupSelectList(AddressViewModel viewModel)
        {
            viewModel.CountryList = viewModel.CountryId == null ? new SelectList(_countryRepository.GetAll(), "CountryId", "CountryName") : new SelectList(_countryRepository.GetAll(), "CountryId", "CountryName", viewModel.CountryId);

            viewModel.StateParishList = viewModel.StateParishId == null ? new SelectList(_stateParishRepository.GetAll(), "StateParishId", "StateParishName") : new SelectList(_stateParishRepository.GetAll(), "StateParishId", "StateParishName", viewModel);

            return viewModel;
        }
    }
}
