using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CageFlix.Infrastructure;
using CageFlix.DAL;

namespace CageFlix.Controllers
{
    public class MoviesController : BaseController
    {

        public MoviesController(IUnitOfWork iu) : base(iu) { }

        public ActionResult Index()
        {
            var movies = db.MovieRepository.GetAll();

            return View(movies);
        }

    }
}
