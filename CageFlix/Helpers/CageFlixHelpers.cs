using CageFlix.DAL;
using CageFlix.Infrastructure;
using CageFlix.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CageFlix.Helpers
{
    public class CageFlixHelpers
    {
        private IUnitOfWork context;

        public CageFlixHelpers(IUnitOfWork context)
        {
            this.context = context;
        }

        public double GetAvgCageFlixScore(Movie movie)
        {
            double avgRating = 0;
            var usermovies = context.UserMovieRepository.Get(um => um.Movie.ID == movie.ID && um.Rating != 0);
            int numUserMovies = usermovies.Count();
            if (numUserMovies != 0)
                avgRating = Math.Round(usermovies.Average(um => um.Rating), 1);
            return avgRating;
        }
    }
}