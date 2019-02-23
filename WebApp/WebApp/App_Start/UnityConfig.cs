using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity;
using System.Web;
using TrackerEnabledDbContext.Identity;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;
using WebApp.Models;
using WebApp.Repositories.Implementations;
using WebApp.Repositories.Interfaces;
using WebApp.Services.Implementations.UserInfo;
using WebApp.Services.Interfaces.UserInfo;
using WebApp.ViewModels;

namespace WebApp
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, ApplicationDbContext>(new PerRequestLifetimeManager());
            container.RegisterType(typeof(TrackerIdentityContext<ApplicationUser>), typeof(ApplicationDbContext));

            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new InjectionConstructor(new ApplicationDbContext()));

            //Below - Generic Interface to Generic Concrete Class
            container.RegisterType(typeof(IRepository<,>), typeof(Repository<,>), new PerRequestLifetimeManager());
            //Below - Generic Interface to Non-Generic Concrete Class
            container.RegisterType(typeof(IAddressService<AddressViewModel, Address, int>), typeof(AddressService), new PerRequestLifetimeManager());
        }
    }
}
