using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CageFlix.DAL;
using CageFlix.Infrastructure;
using WebMatrix.WebData;
using CageFlix.Models;

namespace CageFlix.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork uow) : base(uow) { }

        //ajax - add a movie to a user
        public JsonResult AddMovie(int id)
        {
            var user = db.UserProfileRepository.GetByID(WebSecurity.CurrentUserId);
            var movie = db.MovieRepository.GetByID(id);
            user.UserMovies.Add(new UserMovie { UserProfile = user, Movie = movie });
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
                user.UserMovies.Add(new UserMovie { UserProfile = user, Movie = movie, Rating = rating });
            else
                usermovie.Rating = rating;

            db.Save();
            return Json(new { status = "success" });
        }
    }
}
