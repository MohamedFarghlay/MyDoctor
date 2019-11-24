using MyDoctor.Models;
using MyDoctor.MyDoctorDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDoctor.Controllers
{

    public class HomeController : Controller
    {
        MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
        MyDoctorRepository doctorDBRepo = new MyDoctorRepository();



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        //Get : LogIn
        public ActionResult LogIn()
        {
         

            if (Session["userEmail"] != null)
            {
                ViewBag.title = "Dashboard";
                if (ViewBag.Patientid != 0)
                {
                    return RedirectToAction("PatientDashboard", "Patient", new { userEmail = Session["userEmail"].ToString() });
                }
                else
                {
                    return RedirectToAction("DoctorDashboard", "Doctor", new { username = Session["userEmail"].ToString() });
                }
            }


            return View("LogIn");
           
        }

        //Post : LogIn
        [HttpPost]
        public ActionResult LogIn(UserLogIn user)
        {
            if ((user.Password == null) || (user.Email == null))
            {
                return View(user);
            }

            //encrypt the password
            string pass = EncryptPassword.encryptPassword(user.Password);

            //Check The Existance of the user
            var userLoggedIn = DoctorDBContext.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == pass);
            if(userLoggedIn!=null)
            {
                //if it's a patient display the patient dahsboard
                if (userLoggedIn.PatientID != 0)
                {
                    
                    Session["userEmail"] = userLoggedIn.Email;
                    Session["LoggedPatientID"] = userLoggedIn.ID;
                    ViewBag.Patientid = userLoggedIn.PatientID;
                
                    return RedirectToAction("PatientDashboard", "Patient", new { username = userLoggedIn.Email });
                }
                
                //if it's a doctor display doctor dashboard
                else
                {
                    ViewBag.triedOnce = "Yes";
                    Session["username"] = userLoggedIn.FirstName;
                    ViewBag.Doctorid = userLoggedIn.DoctorID;
                    //return View("PatientDashboard", new { username = userLoggedIn.FirstName });
                    return RedirectToAction("DoctorDashboard", "Doctor", new { username = userLoggedIn.FirstName });
                }
            }
            else
            {
                ViewBag.triedOnce = "Yes";

                return View();
            }

        }


        public ActionResult DoctorRegister()
        {
            return RedirectToAction("DoctorRegister", "Doctor");
        }

        public ActionResult Doctors()
        {
            return RedirectToAction("Doctors", "Doctor");
        }

        public ActionResult PatientRegister()
        {
            return RedirectToAction("PatientRegister", "Patient");
        }



        public ActionResult Error()
        {
            return View();
        }
    }
}