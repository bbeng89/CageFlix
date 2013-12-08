using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CageFlix.Models;
using CageFlix.Infrastructure;
using CageFlix.DAL;
using CageFlix.ViewModels;

namespace CageFlix.Controllers
{
    public class HomeController : BaseController
    {
        //Ninject will inject uow - then we need to pass it to the base controller
        public HomeController(IUnitOfWork uow) : base(uow) { }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
