using CageFlix.Areas.Admin.ViewModels;
using CageFlix.DAL;
using CageFlix.Infrastructure;
using CageFlix.Models;
using CageFlix.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CageFlix.ViewModels;
using WebMatrix.WebData;

namespace CageFlix.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {

        public UsersController(IUnitOfWork uow) : base(uow) { }

        public ActionResult Index(int? page, string search)
        {
            IQueryable<UserProfile> users;
            if (search != null)
                users = db.UserProfileRepository.Get(up => up.UserName.Contains(search)).OrderByDescending(up => up.JoinDate);
            else
                users = db.UserProfileRepository.GetAll().OrderByDescending(up => up.JoinDate);
            var vm = new UsersViewModel { Users = new PagedListViewModel<UserProfile>(users, page), Search = search };
            return View(vm);
        }

        public ActionResult Admins(int? page, string search)
        {
            List<UserProfile> users = new List<UserProfile>();
            string[] unames = Roles.GetUsersInRole("Admin");
            foreach (var name in unames)
            {
                users.Add(db.UserProfileRepository.Get(u => u.UserName == name).Single());
            }
            var vm = new UsersViewModel { Users = new PagedListViewModel<UserProfile>(users.AsQueryable(), page), Search = search };
            return View(vm);
        }

        public ActionResult NewAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAdmin(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { JoinDate = DateTime.Now });
                    Roles.AddUserToRole(model.UserName, "Admin");
                    this.SetAlert("New admin successfully added.", AlertType.Success);
                    return RedirectToAction("admins", "users", new { area = "admin" });
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var user = db.UserProfileRepository.GetByID(id);
            db.UserProfileRepository.Delete(user);
            this.SetAlert(user.UserName + " has been successfully deleted", AlertType.Success);
            db.Save();
            return RedirectToAction("index");
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

    }
}
