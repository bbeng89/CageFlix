using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CageFlix.Models;
using WebMatrix.WebData;
using System.Web.Security;

namespace CageFlix.Infrastructure
{
    public class DatabaseSecurityInitializer : DropCreateDatabaseAlways<CageFlixContext>
    {
        /// <summary>
        /// Initializes membership and creates admin user with username "admin" and password "password"
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(CageFlixContext context)
        {
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (!roles.RoleExists("User"))
            {
                roles.CreateRole("User");
            }
            if (membership.GetUser("admin", false) == null)
            {
                membership.CreateUserAndAccount("admin", "password", new Dictionary<string,object>{ {"Email", "admin@cageflix.com" } });
            }
            if (!roles.GetRolesForUser("admin").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });
            }
            AddMovies(context);
        }

        private void AddMovies(CageFlixContext context)
        {
            //TODO: seed all nic cage movies here
        }
    }
}