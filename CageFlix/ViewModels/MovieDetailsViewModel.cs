using CageFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CageFlix.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }

        public int NumRatings { get; set; }

        public double AvgRating { get; set; }

        public IEnumerable<UserMovie> RecentShitsAndGiggles { get; set; } //TODO
    }
}