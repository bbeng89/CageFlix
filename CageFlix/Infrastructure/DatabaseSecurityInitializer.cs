﻿using System;
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
            context.Movies.Add(new Movie { Title = "Fast Times at Ridgemont High", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/120401662.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Valley Girl", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/13161.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Rumble Fish", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/15386.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Racing with the Moon", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/12068.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Cotton Club", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/16936.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Birdy", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/15889.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Boy in Blue", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/684611458.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Peggy Sue Got Married", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/11025.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Raising Arizona", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/10205.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Moonstruck", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/10256.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Vampire's Kiss", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/14407.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Never on Tuesday", RottenTomatoesApiUrl = "" });
            context.Movies.Add(new Movie { Title = "Tempo di uccidere", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/771252813.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Fire Birds", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/11389.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Wild at Heart", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/13179.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Zandalee", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/519409020.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Honeymoon in Vegas", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/11435.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Amos & Andrew", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/12692.json" });
            context.Movies.Add(new Movie { Title = "Red Rock West", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/14708.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Deadfall", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/404303284.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Guarding Tess", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/12738.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "It Could Happen to You", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/11028.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Trapped in Paradise", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/11376.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Kiss of Death", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/15057.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Leaving Las Vegas", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/13165.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Rock", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/12970.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Con Air", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/13119.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Face/Off", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/13172.json" });
            context.Movies.Add(new Movie { Title = "City of Angels", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/10287.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Snake Eyes", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/14290.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "8MM", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/13766.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Bringing Out the Dead", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/16493.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Gone in Sixty Seconds", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/17108.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Family Man", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/10203.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Captain Corelli's Mandolin", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/14200.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Christmas Carol: The Movie", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/11826.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Windtalkers", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/13794.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Sonny", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/15412.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Adaptation", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/13212.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Matchstick Men", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/11033.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "National Treasure", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/10016.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Lord of War", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/7583.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Weather Man", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/8919.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Ant Bully", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/205091258.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "World Trade Center", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/248007780.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Wicker Man", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/287864910.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Ghost Rider", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/364555500.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Grindhouse", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/460859831.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Next", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/611219283.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "National Treasure: Book of Secrets", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/632295045.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Bangkok Dangerous", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770681773.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Knowing", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770782161.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "G-Force", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770796963.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Bad Lieutenant: Port of Call - New Orleans", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770783617.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Astro Boy", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770681511.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Kick-Ass", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770786150.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Sorcerer's Apprentice", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770796548.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Season of the Witch", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770816170.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Drive Angry", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770858012.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Seeking Justice", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770875167.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Trespass", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/771208334.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Ghost Rider: Spirit of Vengeance", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/771201075.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Stolen", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/771309696.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "The Croods", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/770818015.json?apikey=nppmufmwghxr98525amxup29" });
            context.Movies.Add(new Movie { Title = "Joe", RottenTomatoesApiUrl = "" });
            context.Movies.Add(new Movie { Title = "The Frozen Ground", RottenTomatoesApiUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/771351267.json?apikey=nppmufmwghxr98525amxup29" });

            context.SaveChanges();
        }
    }
}