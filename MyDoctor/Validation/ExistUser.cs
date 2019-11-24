using MyDoctor.MyDoctorDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Validation
{
    public class ExistUser : ValidationAttribute
    {
        MyDoctorDBContext doctorDB = new MyDoctorDBContext();

        public override bool IsValid(object value)
        {
            int id = int.Parse(value.ToString());
            User user = doctorDB.Users.Where(u => u.ID == id).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                CheckPasswordValidation.user = user;
            }
            return true;
        }
    }
}