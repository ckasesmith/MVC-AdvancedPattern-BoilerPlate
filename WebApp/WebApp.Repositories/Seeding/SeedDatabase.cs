using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApp.Models;
using WebApp.Repositories.Implementations;

namespace WebApp.Repositories.Seeding
{
    public class SeedDatabase
    {


        public static void ExecSeedDatabase(ApplicationDbContext context)
        {
            CreateAdminUser(context);
            UserInfoSeeding.SeedDatabase(context);
            SaveChanges(context);
        }

        private static void CreateAdminUser(ApplicationDbContext context)
        {
            if (context.Users.Any()) return;
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var userLogin = new IdentityUserLogin();
            // Add missing roles
            var role = roleManager.FindByName("Admin");
            if (role == null)
            {
                role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            // Create test users
            var user = userManager.FindByEmail("conroyksmith@gmail.com");
            if (user != null) return;
            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "conroyksmith@gmail.com",
                Email = "conroyksmith@gmail.com",
                PhoneNumber = "187612345678",
                FirstName = "Conroy",
                LastName = "Smith"
            };

            userManager.Create(newUser, "password");


            userManager.SetLockoutEnabled(newUser.Id, false);
            userManager.AddToRole(newUser.Id, "Admin");
            
        }
        /// <summary>
        /// Custom Code during migrations to see certain errors
        /// </summary>
        /// <param name="context"></param>
        private static void SaveChanges(ApplicationDbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                Console.Write(sb.ToString());
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}