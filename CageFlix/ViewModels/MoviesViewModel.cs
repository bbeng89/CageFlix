using CageFlix.Helpers;
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
        public string Filter { get; set; }
        public PagedListViewModel<Movie> Movies { get; private set; }
        public List<UserMovie> UserMovies { get; private set; }
        public CageFlixHelpers Helpers { get; private set; }

        public MoviesViewModel(PagedListViewModel<Movie> movies, CageFlixHelpers helpers, UserProfile user = null)
        {
            this.Movies = movies;
            this.Helpers = helpers;

            if (user != null)
            {
                this.UserMovies = user.UserMovies.ToList();
            }
        }

        // custom methods
        public bool UserHasSeenMovie(Movie movie)
        {
            return this.UserMovies != null && this.UserMovies.Select(um => um.MovieID).Contains(movie.ID);
        }

        public int GetUserRating(Movie movie)
        {
            if (this.UserHasSeenMovie(movie))
                return this.UserMovies.SingleOrDefault(um => um.Movie == movie).Rating;

            return 0;
        }

        public bool UserHasReviewedMovie(Movie movie)
        {
            var usermovie = this.UserMovies.Single(um => um.MovieID == movie.ID);
            return this.UserMovies != null && (usermovie.Shits != null || usermovie.Giggles != null);
        }
    }
}