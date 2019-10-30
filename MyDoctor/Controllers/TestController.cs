using MyDoctor.MyDoctorDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDoctor.Controllers
{
    public class TestController : Controller
    {
        // GET: Display
        MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
        MyDoctorRepository doctordb = new MyDoctorRepository();
        public ActionResult Display()
        {
            Patient patient = new Patient()
            {
                PatientID = 1
            };
            Patient pa = new Patient()
            {
                PatientID = 4
            };


            List<User> users = doctordb.GetUsers();
            
            return View(users);
        }

        //Get : Create
        public ActionResult Create()
        {
            return View();
        }

        //Post : Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            User newUser = new MyDoctorDB.User();
            newUser.ID = 3;
            newUser.PatientID = 8;
            newUser.DoctorID = 9;
            
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

            return View("Display",newUser);
            }
            return View();
        }


    }
}