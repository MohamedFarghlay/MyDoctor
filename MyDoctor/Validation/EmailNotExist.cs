using MyDoctor.MyDoctorDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Validation
{
    public class EmailNotExist : ValidationAttribute
    {

        MyDoctorDBContext doctorDB = new MyDoctorDBContext();
        public override bool IsValid(object value)
        {
            if (value is string)

            {
                string Email = value.ToString();
                User user = doctorDB.Users.Where(u => u.Email == Email).FirstOrDefault();
                if (user == null) //user not found 
                {
                    return false;
                }
                else // if Email Exist -> Check The password of that user
                {
                    CheckPassword.user = user;
                }

            }
            return true;
        }

    }
}