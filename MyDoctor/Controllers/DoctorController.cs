using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDoctor.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult DoctorDashboard()
        {
            return View();
        }

        //Get : Register
        public ActionResult DoctorRegister()
        {
            return View();
        }

        public ActionResult Doctors()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return RedirectToAction("MyProfile", "Users");
        }
    }
}