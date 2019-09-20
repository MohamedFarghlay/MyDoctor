using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyDoctor
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "index",
              url: "index",
              defaults: new { controller = "Home", action = "Index" }
              );

            routes.MapRoute(
              name: "Contact",
              url: "contact",
              defaults: new { controller = "Home", action = "Contact" }
              );

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About" }
                );
            routes.MapRoute(
                name: "LogIn",
                url: "login",
                defaults: new { controller = "Home", action = "LogIn" }
                );
            routes.MapRoute(
                name: "LogIn2",
                url: "login2",
                defaults: new { controller = "Home", action = "LogIn2" }
                );
            routes.MapRoute(
              name: "DoctorRegisterr",
              url: "DoctorRegisterr",
              defaults: new { controller = "Doctor", action = "DoctorRegister" }
              );

            routes.MapRoute(
                name: "Doctors",
                url: "Doctors",
                defaults: new { controller = "Doctor", action = "Doctors" }
               );
            routes.MapRoute(
                name: "PatientRegister",
                url: "PatientRegister",
                defaults: new { controller = "Patient", action = "PatientRegister" }

                );
            routes.MapRoute(
                name: "MyProfile",
                url: "MyProfile",
                defaults: new { controller = "Users", action = "MyProfile" }


                );

            routes.MapRoute(
                name: "DoctorDashboard",
                url: "DoctorDashboard",
                defaults: new { controller = "Doctor", action = "DoctorDashboard" }

                );
            routes.MapRoute(
                 name: "PatientDashboard",
                 url: "PatientDashboard",
                 defaults: new { controller = "Patient", action = "PatientDashboard" }

             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
