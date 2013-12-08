using CageFlix.Models;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CageFlix.ViewModels
{
    public class StatsViewModel : Controller
    {
        public int TotalMovies { get; set; }
        public int TotalRatings { get; set; }

        public Movie LeastViewed { get; set; }
        public Movie MostViewed { get; set; }

        public Movie LowestRated { get; set; }
        public Movie HighestRated { get; set; }
        public double AverageRating { get; set; }

        public Movie ShortestRuntime { get; set; }
        public Movie LongestRuntime { get; set; }
        public int AverageRuntime { get; set; }

        public Dictionary<string, int> MpaaRatingsBreakdown { get; set; }
        public Dictionary<int?, int> YearBreakdown { get; set; }
        public List<UserRatingsDistribution> UserRatingsDistribution { get; set; }
    }

    public class UserRatingsDistribution
    {
        public UserRatingsDistribution(string color, int rating, int percentage)
        {
            this.color = color;
            this.rating = rating;
            this.percentage = percentage;
        }

        public string color { get; set; }
        public int rating { get; set; }
        public int percentage { get; set; }
    }
}