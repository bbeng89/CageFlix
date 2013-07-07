using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CageFlix.DAL;

namespace CageFlix.Infrastructure
{
    public enum AlertType { Success, Error, Info, Warning }

    public class BaseController : Controller
    {
        protected IUnitOfWork db;
        protected bool disposed;

        public BaseController(IUnitOfWork uow)
        {
            this.db = uow;
        }

        public void SetAlert(string message, AlertType type)
        {
            TempData["message"] = message;

            switch (type)
            {
                case AlertType.Success:
                    TempData["message-class"] = "alert-success";
                    break;
                case AlertType.Error:
                    TempData["message-class"] = "alert-error";
                    break;
                case AlertType.Info:
                    TempData["message-class"] = "alert-info";
                    break;
                case AlertType.Warning:
                    TempData["message-class"] = "";
                    break;
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
