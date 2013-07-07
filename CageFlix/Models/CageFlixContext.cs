using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CageFlix.Models
{
    public class CageFlixContext : DbContext
    {
        public CageFlixContext()
            : base("CageFlixContext")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
    }
}