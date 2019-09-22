using MyDoctor.MyDoctorDB;
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
        MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
        MyDoctorRepository doctordb = new MyDoctorRepository();

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
        
        //Post : PatientRegiser
        [HttpPost]
        public ActionResult PatientRegister(User  user)
        {

            User newUser = new MyDoctorDB.User();
            
            

            if (ModelState.IsValid)
            {

                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.Email = user.Email;
                newUser.PhoneNumner = user.PhoneNumner;
                newUser.Password = user.Password;
                newUser.gender = user.gender;
                newUser.DateOfBirth = user.DateOfBirth;


                doctordb.SetUser(newUser);

                return View("PatientDashboard");
            }
            return View();
        }
    }
}