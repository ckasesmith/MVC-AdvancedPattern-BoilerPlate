using System.Collections.Generic;
using System.Data.Entity.Migrations;
using WebApp.Models;
using WebApp.Repositories.Implementations;

namespace WebApp.Repositories.Seeding
{
    public class UserInfoSeeding
    {
        public static void SeedDatabase(ApplicationDbContext context)
        {
            var countries = new List<Country>
            {
                new Country {Capital = "Kingston", CountryName = "Jamaica", CountryId = 1, Tld = "JM"}
            };
            countries.ForEach(x => context.Countries.AddOrUpdate(p => p.CountryName, x));
            //Add Parishes
            var parishes = new List<StateParish>
            {
                new StateParish {CountryId = 1,StateParishName = "Clarendon"},
                new StateParish {CountryId = 1,StateParishName = "Hanover"},
                new StateParish {CountryId = 1,StateParishName = "Manchester"},
                new StateParish {CountryId = 1,StateParishName = "Kingston"},
                new StateParish {CountryId = 1,StateParishName = "Portland"},
                new StateParish {CountryId = 1,StateParishName = "St. Ann"},
                new StateParish {CountryId = 1,StateParishName = "St. Elizabeth"},
                new StateParish {CountryId = 1,StateParishName = "St. James"},
                new StateParish {CountryId = 1,StateParishName = "St. Andrew"},
                new StateParish {CountryId = 1,StateParishName = "St. Mary"},
                new StateParish {CountryId = 1,StateParishName = "St. Thomas"},
                new StateParish {CountryId = 1,StateParishName = "St. Catherine"},
                new StateParish {CountryId = 1,StateParishName = "Westmoreland"},
                new StateParish {CountryId = 1,StateParishName = "Trelawny"},
            };


            parishes.ForEach(x => context.StateParishes.AddOrUpdate(p => p.StateParishName, x));
           
        }
    }
}
