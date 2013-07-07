using CageFlix.DAL;
using CageFlix.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CageFlix.Areas.Admin.ViewModels;
using CageFlix.Models;

namespace CageFlix.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork uow) : base(uow) { }

        public ActionResult Index(int? page, string search)
        {
            return View();
        }
    }
}
