using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MyDoctor.MyDoctorDB
{
    public class MyDoctorRepository
    {
        //Get All Users
        public List<User> GetUsers()
        {
            MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
            return DoctorDBContext.Users.ToList();
        }


        //Create New User
        public void SetUser(User user)
        {
            //MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
            //DoctorDBContext.Users.Add(user);
            //DoctorDBContext.SaveChanges();

            try
            {
                MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
                DoctorDBContext.Users.Add(user);
                DoctorDBContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }


        //Update An Existing User
        public void UpdateUser(User newUser)
        {
            //MyDoctorDBContext DoctorDB = new MyDoctorDBContext();
            //DoctorDB.Entry(newUser).State = EntityState.Modified;
            //DoctorDB.SaveChanges();
            try
            {
                MyDoctorDBContext DoctorDB = new MyDoctorDBContext();
                DoctorDB.Entry(newUser).State = EntityState.Modified;
                DoctorDB.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


        }

        //Delete An Existing User
        public void DeleteUser(User user)
        {

            //MyDoctorDBContext DoctorDB = new MyDoctorDBContext();
            //User deletedUser = DoctorDB.Users.Where(u => u.ID == user.ID).FirstOrDefault();
            //DoctorDB.Users.Remove(deletedUser);
            //DoctorDB.SaveChanges();
            try
            {
                MyDoctorDBContext DoctorDB = new MyDoctorDBContext();
                User deletedUser = DoctorDB.Users.Where(u => u.ID == user.ID).FirstOrDefault();
                DoctorDB.Users.Remove(deletedUser);
                DoctorDB.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        //Search For a User
        public bool Search(User user)
        {
            MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
            if (DoctorDBContext.Users.Find(user.ID) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Check For Existing Emails
        public bool EmailAlreadyRegister(string email)
        {


            if (email == null)
            {
                return true;
            }

            else
            {
                List<User> ExsitingUsers = new List<User>();
                ExsitingUsers = GetUsers();
                foreach (var item in ExsitingUsers)
                {
                    if (item.Email.Equals(email))
                    {
                        return false;
                    }
                }
            }
            return true;

        }


        //set Patient 
        public void SetPatient(Patient patient)
        {
            //MyDoctorDBContext doctorDB = new MyDoctorDBContext();
            //doctorDB.Patients.Add(patient);
            //doctorDB.SaveChanges();

            try
            {
                MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
                DoctorDBContext.Patients.Add(patient);
                DoctorDBContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }

        //Delete An Existing Patient
        public void DeletePatient(int UserID)
        {

            //MyDoctorDBContext DoctorDB = new MyDoctorDBContext();
            //Patient deletedPatient = DoctorDB.Patients.Where(p => p.PatientID == PatientID).FirstOrDefault();
            //DoctorDB.Patients.Remove(deletedPatient);
            //DoctorDB.SaveChanges();
            try
            {
                MyDoctorDBContext DoctorDB = new MyDoctorDBContext();
                //get the patient
                Patient deletedPatient = DoctorDB.Patients.Where(p => p.PatientID == UserID).FirstOrDefault();
                if (deletedPatient != null)
                {
                    //delete the patient
                    DoctorDB.Patients.Remove(deletedPatient);
                    DoctorDB.SaveChanges();
                }
                

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }


    }
}