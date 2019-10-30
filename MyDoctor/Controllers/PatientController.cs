using MyDoctor.Models;
using MyDoctor.MyDoctorDB;
using MyDoctor.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyDoctor.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
        MyDoctorRepository doctordb = new MyDoctorRepository();
        Patient patientUser = new Patient();
      
        //Get : Dashboard 
        public ActionResult PatientDashboard(string userName)
        {
            if (Session["username"] == null)
            {
                return View("LogIn");
            }
            else {
                ViewBag.userName = userName;
                return View();
            }
        }


        //Get : MyProfile
        public ActionResult MyProfile(int? id=20)
        {
            if (id != null)
            {


                List<User> users = doctordb.GetUsers();

                Patient patient = new Patient();
                patient.users = users.Where(user => user.ID == id).FirstOrDefault();
                if (patient.users != null)
                {
                    return View(patient.users);

                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            return RedirectToAction("Error", "Home");



        }


        //Get  : Edit
        public ActionResult Edit(int? id)
        {

            EmailExist.flag = true;

            var user = DoctorDBContext.Users.Where(u => u.ID == id).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("Error", "Home");
        }

        //Post : Edit
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {


            User targetsUser = new MyDoctorDB.User();
            targetsUser = DoctorDBContext.Users.Where(u => u.ID == user.ID).FirstOrDefault();
            if (targetsUser != null)
            {
                targetsUser.FirstName = user.FirstName;
                targetsUser.LastName = user.LastName;
                targetsUser.Email = user.Email;
                targetsUser.PhoneNumner = user.PhoneNumner;
                targetsUser.Password = user.Password;

                targetsUser.DateOfBirth = user.DateOfBirth;

                doctordb.UpdateUser(targetsUser);
                return RedirectToAction("Display", "Test");
            }

            return View(user);



        }

        //Get : Register
        public ActionResult PatientRegister()
        {
            return View();
        }

        //Post : PatientRegiser
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PatientRegister(User user)
        {

            User newUser = new User();
            Patient patient = new Patient();
            if (ModelState.IsValid)
            {
                string EncryptedPassword = EncryptPassword.encryptPassword(user.Password);
                user.Password = EncryptedPassword;
                user.PatientID = 1;

                patient.users = user;
                patient.PatientID = 0;
                doctordb.SetPatient(patient);

              

                //doctordb.UpdateUser(user);
                //user.PatientID = patientID;
                //user.DoctorID = 0;
                ////new patient
                ////user.PatientID++;
                ////encrypt the password
                //string EncryptedPassword = EncryptPassword.encryptPassword(user.Password);
                ////string decryptedPassword = DecryptPassword.decryptPassword(EncryptedPassword);
                //newUser.FirstName = user.FirstName;
                //newUser.LastName = user.LastName;
                //newUser.Email = user.Email;
                //newUser.PhoneNumner = user.PhoneNumner;
                //newUser.Password = EncryptedPassword;
                //newUser.gender = user.gender;
                ////newUser.DateOfBirth = user.DateOfBirth;
                //doctordb.SetUser(newUser);

                return View("PatientDashboard");
            }
            return View(user);
        }


        //Get :LogIn
        public ActionResult LogIn()
        {
            //if user is already logged in -> view it's dashboard directly
            if (Session["username"] != null)
            {
                ViewBag.title = "Dashboard";
                return View("PatientDashboard", new { username = Session["username"].ToString() });
            }

            
            return View("LogIn");
        }

        //Post : LogIn
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLogIn user)
        {
            if ((user.Password == null) || (user.Email == null))
            {
                return View(user);
            }

            string pass = EncryptPassword.encryptPassword(user.Password);


            //Check The Existance of the user

            var userLoggedIn = DoctorDBContext.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == pass);
            if (userLoggedIn != null) //found the user
            {
                ViewBag.message = "Logged In ";
                ViewBag.triedOnce = "Yes";

                Session["username"] = userLoggedIn.FirstName;
                return View("PatientDashboard", new { username = userLoggedIn.FirstName });
            }
            else
            {
                ViewBag.triedOnce = "Yes";
               
                return View();
            }
        }

        //Get : ConfirmationDeleting
        public ActionResult ConfirmationDeleting()
        {
            return View();
        }


        //Get : Delete
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var deletedUser = DoctorDBContext.Users.Where(u => u.ID == id).FirstOrDefault();
                if (deletedUser != null)
                {
                    return View(deletedUser);
                }
            }
            //return RedirectToAction("Error", "Home");
            return View("Error");
        }

        //Post : Delete
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            User deletedUser = DoctorDBContext.Users.Where(u => u.ID == user.ID).FirstOrDefault();
            if (deletedUser != null)
            {
                //First Delete The Patient That Hold this user
                doctordb.DeletePatient(deletedUser.ID);

                //then delete the user
                doctordb.DeleteUser(deletedUser);
                return RedirectToAction("Display", "Test");
            }

            return RedirectToAction("Error", "Home");

        }
    }
}