using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CageFlix.DAL;
using CageFlix.Infrastructure;
using WebMatrix.WebData;
using CageFlix.Models;
using CageFlix.ViewModels;

namespace CageFlix.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork uow) : base(uow) { }

        //user profile for user with id
        public ActionResult Index(int id, int? page)
        {
            var user = db.UserProfileRepository.GetByID(id);
            var movies = user.UserMovies.OrderByDescending(um => um.DateAdded).AsQueryable();
            return View(new UserProfileViewModel(user, movies, page));
        }

        //ajax - add a movie to a user
        public JsonResult AddMovie(int id)
        {
            var user = db.UserProfileRepository.GetByID(WebSecurity.CurrentUserId);
            var movie = db.MovieRepository.GetByID(id);
            user.UserMovies.Add(new UserMovie { UserProfile = user, Movie = movie, DateAdded = DateTime.Now });
            db.Save();
            return Json(new { status = "success" });
        }

        //ajax - add a rating to a UserMovie (and create the UserMovie if it doesn't exist)
        public JsonResult RateMovie(int id, int rating)
        {
            var user = db.UserProfileRepository.GetByID(WebSecurity.CurrentUserId);
            var movie = db.MovieRepository.GetByID(id);
            var usermovie = user.GetUserMovie(movie);

            if (usermovie == null)
                user.UserMovies.Add(new UserMovie { UserProfile = user, Movie = movie, Rating = rating, DateAdded = DateTime.Now });
            else
                usermovie.Rating = rating;

            db.Save();
            return Json(new { status = "success" });
        }

        public ActionResult Stats()
        {
            IQueryable<UserMovie> movies = db.UserMovieRepository.GetAll();
            StatsViewModel stats = new StatsViewModel();

            stats.LowestRated = movies.Where(m => m.Rating == movies.Min(um => um.Rating)).Select(rm => rm.Movie).First();
            stats.HighestRated = movies.Where(m => m.Rating == movies.Max(um => um.Rating)).Select(rm => rm.Movie).First();

            return View(stats);
        }
    }
}
