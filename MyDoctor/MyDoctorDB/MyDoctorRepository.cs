using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDoctor.MyDoctorDB
{
    public class MyDoctorRepository
    {
        public List<User> GetUsers()
        {
            MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
            return DoctorDBContext.Users.ToList();
        }

        public void SetUser(User user)
        {
            MyDoctorDBContext DoctorDBContext = new MyDoctorDBContext();
            DoctorDBContext.Users.Add(user);
            DoctorDBContext.SaveChanges();
        }
    }
}