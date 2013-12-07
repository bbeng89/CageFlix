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

        public ActionResult Index(int? page, string search, string order, string filter)
        {
            IQueryable<Movie> movies = db.MovieRepository.GetAll();
            UserProfile user = null;

            if (User.Identity.IsAuthenticated)
                user = db.UserProfileRepository.GetByID(WebSecurity.CurrentUserId);

            //FILTER
            if (user != null && filter == "notseen")
            {
                var seenIds = user.UserMovies.Select(um => um.MovieID);
                movies = movies.Where(m => !seenIds.Contains(m.ID));
            }
            else if (user != null && filter == "seen")
            {
                var seenIds = user.UserMovies.Select(um => um.MovieID);
                movies = movies.Where(m => seenIds.Contains(m.ID));
            }

            //SEARCH
            if (search != null)
                movies = movies.Where(m => m.Title.Contains(search));

            //ORDER
            if (order == "asc")
                movies = movies.OrderBy(m => m.ReleaseYear);
            else if (order == "netflix")
                movies = movies.OrderByDescending(m => m.NetflixLink);
            else
                movies = movies.OrderByDescending(m => m.ReleaseYear);

            var helper = new CageFlixHelpers(db);
            var vm = new MoviesViewModel(new PagedListViewModel<Movie>(movies, page), helper, user) { Search = search, Order = order, Filter = filter };
            return View(vm);
        }

        public ActionResult Details(int id)
        {
            var movie = db.MovieRepository.GetByID(id);
            var helper = new CageFlixHelpers(db);
            var vm = new MovieDetailsViewModel(movie, helper);
            return View(vm);
        }

        //submitting a review
        [HttpPost]
        public ActionResult Details(ReviewViewModel review)
        {
            var user = db.UserProfileRepository.GetByID(WebSecurity.CurrentUserId);
            var usermovie = user.UserMovies.Single(um => um.MovieID == review.MovieID);
            usermovie.Shits = review.Shits;
            usermovie.Giggles = review.Giggles;
            db.Save();
            this.SetAlert("Your review has been added", AlertType.Success);
            return RedirectToAction("details", new { id = review.MovieID });
        }
    }
}
