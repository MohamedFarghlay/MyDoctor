using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyDoctor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Generate Database
            MyDoctorDB.MyDoctorDBContext db = new MyDoctorDB.MyDoctorDBContext();
            if (db.Database.CreateIfNotExists()){

                MyDoctorDB.User user = new MyDoctorDB.User()
                {
                    FirstName = "Mohamed",
                    LastName = "Ali",
                    DateOfBirth = "10-10-1982",
                    Email = "Ali@gmail.com",
                    gender = MyDoctorDB.Gender.Male,
                    Password = "M123456789",
                    PhoneNumner = "01115644897", PatientID=2,DoctorID=4

                };
                MyDoctorDB.Patient patient = new MyDoctorDB.Patient()
                {
                    PatientID = 1
                };
                MyDoctorDB.User user2 = new MyDoctorDB.User()
                {
                    FirstName = "Ahmed",
                    LastName = "AKhaledli",
                    DateOfBirth = "1-8-1990",
                    Email = "Khalled@gmail.com",
                    gender = MyDoctorDB.Gender.Male,
                    Password = "M123456",
                    PhoneNumner = "01005644897", PatientID = 1, DoctorID=2
                  
                   
                };
                MyDoctorDB.Patient patient2 = new MyDoctorDB.Patient()
                {
                    PatientID = 2,
                    
                };

                db.Users.Add(user);
                db.Users.Add(user2);
                db.Patients.Add(patient);
                db.Patients.Add(patient2);
                db.SaveChanges();  

            }
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
