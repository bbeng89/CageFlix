using CageFlix.Areas.Admin.ViewModels;
using CageFlix.DAL;
using CageFlix.Infrastructure;
using CageFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace CageFlix.Areas.Admin.Controllers
{
    public class MoviesController : BaseController
    {
        public MoviesController(IUnitOfWork uow) : base(uow) { }

        public ActionResult Index(int? page, string search)
        {
            IQueryable<Movie> movies;
            if (search != null)
                movies = db.MovieRepository.Get(m => m.Title.Contains(search)).OrderBy(m => m.ReleaseYear);
            else
                movies = db.MovieRepository.GetAll().OrderByDescending(m => m.ReleaseYear);
            var vm = new HomeViewModel { Movies = new PagedListViewModel<Movie>(movies, page), Search = search };
            return View(vm);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(db.MovieRepository.GetByID(id));
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.MovieRepository.Insert(movie);
                db.Save();
                this.SetAlert("Successfully added movie " + movie.Title, AlertType.Success);
                return RedirectToAction("index", "movies");
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var dbMovie = db.MovieRepository.GetByID(movie.ID);
                AutoMapper.Mapper.Map<Movie, Movie>(movie, dbMovie);
                db.Save();
                this.SetAlert("Successfully updated movie " + movie.Title, AlertType.Success);
                return RedirectToAction("index", "movies");
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var movie = db.MovieRepository.GetByID(id);
            db.MovieRepository.Delete(id);
            this.SetAlert("Deleted movie " + movie.Title, AlertType.Info);
            db.Save();
            return RedirectToAction("index");
        }
    }
}
