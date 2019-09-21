
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDoctor.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
      

        public ActionResult PatientDashboard()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return RedirectToAction("MyProfile", "Users");
        }
        //Get : Register
        public ActionResult PatientRegister()
        {
            return View();
        }
        
       
    }
}