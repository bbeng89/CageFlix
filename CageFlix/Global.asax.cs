using CageFlix.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;
using CageFlix.Infrastructure;

namespace CageFlix
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Database.SetInitializer<CageFlixContext>(null);
            //Database.SetInitializer<CageFlixContext>(new DatabaseSecurityInitializer());
            //using (CageFlixContext context = new CageFlixContext())
            //{
            //    context.Database.Initialize(true);
            //}
            WebSecurity.InitializeDatabaseConnection("CageFlixContext", "UserProfile", "ID", "UserName", autoCreateTables: true);

            //Use Ninject for DI
            DependencyResolver.SetResolver(new NinjectDependencyResolver());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}