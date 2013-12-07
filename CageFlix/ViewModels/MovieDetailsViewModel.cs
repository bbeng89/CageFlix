using CageFlix.Helpers;
using CageFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace CageFlix.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }

        public int NumRatings { get; set; }

        public double AvgRating { get; set; }

        //TODO: right now all of the reviews are pulled. We either need to add pagination or pull a select number and add a link to view the rest
        public IEnumerable<UserMovie> RecentShitsAndGiggles { get; set; }

        public CageFlixHelpers Helpers { get; set; }

        public bool UserHasReviewedMovie { get; set; }

        public bool UserHasSeenMovie { get; set; }

        public MovieDetailsViewModel(Movie movie, CageFlixHelpers helpers, UserProfile currentUser)
        {
            this.Movie = movie;
            this.Helpers = helpers;
            this.NumRatings = movie.UserMovies.Count();
            this.AvgRating = helpers.GetAvgCageFlixScore(movie);
            this.RecentShitsAndGiggles = movie.UserMovies.ToList().Where(um => um.Reviewed);
            if (currentUser != null)
            {
                this.UserHasReviewedMovie = currentUser.UserMovies.Where(sg => sg.MovieID == this.Movie.ID && sg.Reviewed).Count() > 0;
                this.UserHasSeenMovie = currentUser.UserMovies.Where(um => um.MovieID == this.Movie.ID).Count() > 0;
            }
            else
            {
                this.UserHasReviewedMovie = false;
                this.UserHasSeenMovie = false;
            }
        }
    }
}