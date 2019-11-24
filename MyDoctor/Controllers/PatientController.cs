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
        public ActionResult PatientDashboard(string userEmail)
        {

            if (userEmail == null)
            {
                return RedirectToAction("LogIn", "Home");
                //return View("LogIn");
            }
            else {
                ViewBag.useremail = userEmail;
                return View();
            }
        }


        //Get : MyProfile
        //[ValidateAntiForgeryToken]
        public ActionResult MyProfile(int? id)
        {
            if (Session["userEmail"] != null)
            {
                id = int.Parse(Session["LoggedPatientID"].ToString());

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
            return RedirectToAction("LogIn", "Home");


        }


        //Get  : Edit
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (Session["userEmail"] != null)
            {
                id = int.Parse(Session["LoggedPatientID"].ToString());
                EmailExist.flag = true;

                var user = DoctorDBContext.Users.Where(u => u.ID == id).FirstOrDefault();
                if (user != null)
                {
                    return View(user);
                }
                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction("LogIn", "Home");

        }

        //Post : Edit
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {

            if (Session["userEmail"] != null)
            {
                User targetsUser = new MyDoctorDB.User();
                targetsUser = DoctorDBContext.Users.Where(u => u.ID == user.ID).FirstOrDefault();
                if (targetsUser != null)
                {
                    if (ModelState.IsValid)
                    {
                        user.Password = EncryptPassword.encryptPassword(user.Password);
                        targetsUser.FirstName = user.FirstName;
                        targetsUser.LastName = user.LastName;
                        targetsUser.Email = user.Email;
                        targetsUser.PhoneNumber = user.PhoneNumber;
                        targetsUser.Password = user.Password;

                        targetsUser.DateOfBirth = user.DateOfBirth;
                        doctordb.UpdateUser(targetsUser);

                        ViewBag.useremail = targetsUser.Email;
                        return View("PatientDashboard");
                    }

                }

                return View(user);
            }
            return RedirectToAction("LogIn", "Home");
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
            if (Session["userEmail"] == null)
            {
                User newUser = new User();
                Patient patient = new Patient();
                if (ModelState.IsValid)
                {
                    //Encrypt The Password Using MD5 Encryption
                    string EncryptedPassword = EncryptPassword.encryptPassword(user.Password);

                    //set user password to encrypted password
                    user.Password = EncryptedPassword;

                    //this User is a Patient 
                    user.PatientID = 1;

                    //set User's Data to patient
                    patient.users = user;

                    //set patient into database
                    doctordb.SetPatient(patient);

                    //Start A new Session
                    Session["userEmail"] = user.Email;

                    //store the id of the patient 
                    Session["LoggedPatientID"] = user.PatientID;

                    //store the email of the patient
                    ViewBag.useremail = user.Email;


                    return View("PatientDashboard");
                }
                return View(user);
            }
            return View("PatientDashboard");
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
        [ValidateAntiForgeryToken]
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
        public ActionResult ConfirmationDeleting2(int? id)
        {
            if (Session["userEmail"] != null)
            {
                id = int.Parse(Session["LoggedPatientID"].ToString());
                if (id != null)
                {
                    User deletedUser = DoctorDBContext.Users.Where(u => u.ID == id).FirstOrDefault();
                    if (deletedUser != null)
                    {
                        ViewBag.deletedUserID = id;
                        return View();
                    }

                }
                return View("Error");
            }
            return RedirectToAction("LogIn", "Home");
        }

        //Post : ConfirmationDeleting
        [HttpPost]
        public ActionResult ConfirmationDeleting2(UserDeleteInfo deletedUser)
        {
            if (Session["userEmail"] != null)
            {
                if (ModelState.IsValid)
                {
                    string DeletedUserPassword = EncryptPassword.encryptPassword(deletedUser.password);
                    User targetUser = DoctorDBContext.Users.Where(u => u.ID == deletedUser.ID).FirstOrDefault();
                    if (targetUser != null)
                    {
                        if (targetUser.Password.Equals(DeletedUserPassword))
                        {
                            Delete(targetUser);
                            Logout();
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {

                            return View();
                        }
                    }

                }
                return View();
            }
            return RedirectToAction("LogIn", "Home");
        }

        //Get : Delete
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (Session["userEmail"] != null)
            {
                id =int.Parse(Session["LoggedPatientID"].ToString());
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
            return RedirectToAction("LogIn", "Home");
        }

        //Post : Delete
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            if (Session["userEmail"] != null)
            {
                User deletedUser = DoctorDBContext.Users.Where(u => u.ID == user.ID).FirstOrDefault();
                if (deletedUser != null)
                {
                    //First Delete The Patient That Hold this user
                    doctordb.DeletePatient(deletedUser.ID);

                    //then delete the user
                    doctordb.DeleteUser(deletedUser);

                }

                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction("LogIn", "Home");

        }

        //Get : Logout
        public ActionResult Logout()
        {
            Session["userEmail"] = null;
            return RedirectToAction("LogIn", "Home");
        }

        


        //Get : MyAppointments
        public ActionResult MyAppointments(int? id)
        {
            if (Session["userEmail"] != null)
            {
                id = int.Parse(Session["LoggedPatientID"].ToString());
                if (id != null)
                {
                    List<Appointment> appointments = DoctorDBContext.Appointments.Where(app => app.PatintID == id).ToList();
                    if (appointments.Count != 0)
                    {
                        ViewBag.NotAppointments = "false";
                        return View(appointments);
                    }
                    ViewBag.NotAppointments = "true";
                    return View();
                }
                return View("Error");
            }
            return RedirectToAction("LogIn", "Home");
        }
        
    }
}