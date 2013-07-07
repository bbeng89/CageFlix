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

        public ActionResult Index(int? page)
        {
            var movies = db.MovieRepository.GetAll().OrderBy(m => m.ReleaseYear);
            return View(new PagedListViewModel<Movie>(movies, page));
        }

        public ActionResult Details(int id)
        {
            var movie = db.MovieRepository.GetByID(id);
            return View(movie);
        }

    }
}
