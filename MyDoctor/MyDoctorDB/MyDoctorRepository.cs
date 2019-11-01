using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
            DoctorDBContext.Users.Add(user);
            DoctorDBContext.SaveChanges();
        }


        //Update An Existing User
        public void UpdateUser(User newUser)
        {
            MyDoctorDBContext DoctorDB = new MyDoctorDBContext();
            DoctorDB.Entry(newUser).State = EntityState.Modified;
            DoctorDB.SaveChanges();

           
        }

        //Delete An Existing User
        public void DeleteUser(User user)
        {
            
            MyDoctorDBContext DoctorDB = new MyDoctorDBContext();
            User deletedUser = DoctorDB.Users.Where(u => u.ID == user.ID).FirstOrDefault();
            DoctorDB.Users.Remove(deletedUser);
            
            DoctorDB.SaveChanges();
        }

        //Search For a User
        public bool Search(User user)
        {
            MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
            if (DoctorDBContext.Users.Find(user.ID) ==null)
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
                    if (item.Email.Equals(email)){
                        return false;
                    }
                }
            }
            return true;

        }
    }
}