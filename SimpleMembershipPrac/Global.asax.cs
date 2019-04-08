using SimpleMembershipPrac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
 
using System.Data.Entity;
using WebMatrix.WebData;
namespace SimpleMembershipPrac
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();




          
           Database.SetInitializer(new MyDBInitializer());
            //above here we set the initializer and then below we call this in context.Database.Initialize(true/false)

            using (var context = new MyAppDbContext())
            { 
                if (!context.Database.Exists())  // !context.Database.CompatibleWithModel(true))
                {
                    context.Database.Create(); //first create the db and then use the initializer class to initialize it.
                   // context.Database.Initialize(true);  // since we are calling the seed manually, so we disabled this.
                    InitializeWebSecurity();
                    new MyDBInitializer().Seed(context); // calling seed method manually.
                }
                else if (context.Database.Exists() && !context.Database.CompatibleWithModel(true))
                {
                    context.Database.Connection.Close();
                    context.Database.Delete();
                    context.Database.Create();
                    //context.Database.Initialize(true);
                    InitializeWebSecurity();
                    new MyDBInitializer().Seed(context);
                }
                else  
                {
                    // finally if database exists and also no model changes are there, then simply initialize the websecurity.
                    // no need to call the seed method.
                    InitializeWebSecurity();
                }
            }

        }

        protected void InitializeWebSecurity() {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("mycon", "UserProfile", "UserId", "UserName", autoCreateTables: true);

        }



    }
}