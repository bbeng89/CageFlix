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

        public JsonResult AddMovie(int id)
        {
            var user = db.UserProfileRepository.GetByID(WebSecurity.CurrentUserId);
            var movie = db.MovieRepository.GetByID(id);
            user.UserMovies.Add(new UserMovie { UserProfile = user, Movie = movie });
            db.Save();
            return Json(new { status = "success" });
        }

    }
}
