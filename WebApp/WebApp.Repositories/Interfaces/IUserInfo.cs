using System.Data.Entity;
using WebApp.Models;

namespace WebApp.Repositories.Interfaces
{
    interface IUserInfo
    {
        //Should list all the DbSets or Interfaces containing DBsets for this feature
        DbSet<Address> Addresses { get; set; }

        DbSet<Country> Countries { get; set; }

        DbSet<StateParish> StateParishes { get; set; }
        
    }
}
