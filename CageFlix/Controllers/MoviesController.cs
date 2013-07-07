using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CageFlix.Infrastructure;
using CageFlix.DAL;
using CageFlix.ViewModels;
using CageFlix.Models;

namespace CageFlix.Controllers
{
    public class MoviesController : BaseController
    {
        public MoviesController(IUnitOfWork iu) : base(iu) { }

        public ActionResult Index(int? page, string search, string order)
        {
            IQueryable<Movie> movies;
            if (search != null)
                movies = db.MovieRepository.Get(m => m.Title.Contains(search));
            else
                movies = db.MovieRepository.GetAll();

            if (order == "asc")
                movies = movies.OrderBy(m => m.ReleaseYear);
            else
                movies = movies.OrderByDescending(m => m.ReleaseYear);

            var vm = new MoviesViewModel { Movies = new PagedListViewModel<Movie>(movies, page), Search = search, Order = order };
            return View(vm);
        }

        public ActionResult Details(int id)
        {
            var movie = db.MovieRepository.GetByID(id);
            return View(movie);
        }

    }
}
