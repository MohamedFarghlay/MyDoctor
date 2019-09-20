using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDoctor.Controllers
{

    public class HomeController : Controller
    {
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

        public ActionResult LogIn()
        {
            return View();
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