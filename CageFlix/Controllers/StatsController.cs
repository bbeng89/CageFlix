﻿using CageFlix.DAL;
using CageFlix.Infrastructure;
using CageFlix.Models;
using CageFlix.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CageFlix.Controllers
{
    public class StatsController : BaseController
    {
        public StatsController(IUnitOfWork uow) : base(uow) { }

        public ActionResult Index()
        {
            IQueryable<Movie> movies = db.MovieRepository.GetAll();
            IQueryable<UserMovie> userMovies = db.UserMovieRepository.GetAll();
            StatsViewModel stats = new StatsViewModel();

            #region MoviesViewed
            //Aggregate movie ID counts to determine min / max
            int leastViewed = userMovies.GroupBy(m => m.MovieID)
                                    .OrderBy(x => x.Count(y => y.MovieID != null))
                                    .Select(x => x.Key).First();
            int mostViewed = userMovies.GroupBy(m => m.MovieID)
                                   .OrderByDescending(x => x.Count(y => y.MovieID != null))
                                   .Select(x => x.Key).First();

            //Select movie based on IDs determined above
            stats.LeastViewed = userMovies.Select(m => m.Movie)
                                      .Where(i => i.ID == leastViewed).First();
            stats.MostViewed = userMovies.Select(m => m.Movie)
                                     .Where(i => i.ID == mostViewed).First();
            #endregion

            #region UserRatings
            stats.LowestRated = userMovies.Where(m => m.Rating == userMovies.Min(um => um.Rating))
                                      .Select(rm => rm.Movie).First();
            stats.HighestRated = userMovies.Where(m => m.Rating == userMovies.Max(um => um.Rating))
                                       .Select(rm => rm.Movie).First();
            stats.AverageRating = userMovies.Average(m => m.Rating);
            #endregion

            #region Runtimes
            stats.ShortestRuntime = movies.Where(m => m.Runtime == movies.Min(x => x.Runtime)).First();
            stats.LongestRuntime = movies.Where(m => m.Runtime == movies.Max(x => x.Runtime)).First();
            stats.AverageRuntime = (int)movies.Average(m => m.Runtime);
            #endregion

            #region MPAARatings
            stats.MpaaRatingsBreakdown = new Dictionary<string, int>()
            {
                {"G", movies.Where(m => m.MpaaRating.Equals("G")).Count()},
                {"PG", movies.Where(m => m.MpaaRating.Equals("PG")).Count()},
                {"PG-13", movies.Where(m => m.MpaaRating.Equals("PG-13")).Count()},
                {"R", movies.Where(m => m.MpaaRating.Equals("R")).Count()},
                {"NC-17", movies.Where(m => m.MpaaRating.Equals("NC-17")).Count()}
            };
            #endregion

            #region YearHistogram
            stats.YearBreakdown = movies.GroupBy(m => m.ReleaseYear)
                                        .Select(x => new
                                         {
                                           Year = x.Key,
                                           Count = x.Count()
                                         }).OrderBy(x => x.Year)
                                           .ToDictionary(d => d.Year, d => d.Count);
            #endregion

            return View(stats);
        }
    }
}