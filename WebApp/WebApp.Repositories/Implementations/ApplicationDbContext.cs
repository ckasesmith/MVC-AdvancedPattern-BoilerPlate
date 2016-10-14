using System.Data.Entity;
using TrackerEnabledDbContext.Identity;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Repositories.Implementations
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
  

        /// <summary>
        /// The interfaces should be used to bring in the tables as needed, they will contain several dbset references to the models
        /// </summary>

    public class ApplicationDbContext : TrackerIdentityContext<ApplicationUser>,IUserInfo
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<StateParish> StateParishes { get; set; }
    }
}