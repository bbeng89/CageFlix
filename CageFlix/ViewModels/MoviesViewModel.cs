using CageFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CageFlix.ViewModels
{
    public class MoviesViewModel
    {
        public string Search { get; set; }
        public string Order { get; set; }
        public PagedListViewModel<Movie> Movies { get; private set; }
        public List<UserMovie> UserMovies { get; private set; }

        public MoviesViewModel(PagedListViewModel<Movie> movies, UserProfile user = null)
        {
            this.Movies = movies;

            if (user != null)
            {
                this.UserMovies = user.UserMovies.ToList();
            }
        }
    }
}