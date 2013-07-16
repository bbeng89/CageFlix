using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CageFlix.Infrastructure;
using CageFlix.DAL;
using CageFlix.ViewModels;
using CageFlix.Models;
using WebMatrix.WebData;
using CageFlix.Helpers;

namespace CageFlix.Controllers
{
    public class MoviesController : BaseController
    {
        public MoviesController(IUnitOfWork iu) : base(iu) { }

        public ActionResult Index(int? page, string search, string order)
        {
            IQueryable<Movie> movies;
            UserProfile user = null;

            if (search != null)
                movies = db.MovieRepository.Get(m => m.Title.Contains(search));
            else
                movies = db.MovieRepository.GetAll();

            if (order == "asc")
                movies = movies.OrderBy(m => m.ReleaseYear);
            else if (order == "netflix")
                movies = movies.OrderByDescending(m => m.NetflixLink);
            else
                movies = movies.OrderByDescending(m => m.ReleaseYear);

            if (User.Identity.IsAuthenticated)
                user = db.UserProfileRepository.GetByID(WebSecurity.CurrentUserId);

            var helper = new CageFlixHelpers(db);
            var vm = new MoviesViewModel(new PagedListViewModel<Movie>(movies, page), helper, user) { Search = search, Order = order };
            return View(vm);
        }

        public ActionResult Details(int id)
        {
            var movie = db.MovieRepository.GetByID(id);
            var helper = new CageFlixHelpers(db);
            var vm = new MovieDetailsViewModel(movie, helper);
            return View(vm);
        }

    }
}
