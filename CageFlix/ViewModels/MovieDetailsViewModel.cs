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

        public MovieDetailsViewModel(Movie movie, CageFlixHelpers helpers)
        {
            this.Movie = movie;
            this.Helpers = helpers;
            this.NumRatings = movie.UserMovies.Count();
            this.AvgRating = helpers.GetAvgCageFlixScore(movie);
            this.RecentShitsAndGiggles = movie.UserMovies.ToList();
            if (WebSecurity.IsAuthenticated)
            {
                var userid = WebSecurity.CurrentUserId;
                this.UserHasReviewedMovie = this.RecentShitsAndGiggles.Where(sg => sg.Reviewed).Select(sg => sg.UserProfileID).Contains(userid);
                this.UserHasSeenMovie = this.RecentShitsAndGiggles.Select(sg => sg.UserProfileID).Contains(userid);
            }
            else
            {
                this.UserHasReviewedMovie = false;
                this.UserHasSeenMovie = false;
            }
        }
    }
}