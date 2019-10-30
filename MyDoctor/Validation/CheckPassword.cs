using MyDoctor.Models;
using MyDoctor.MyDoctorDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Validation
{
    public class CheckPassword : ValidationAttribute
    {
        public static User user { get; set; }



        public override bool IsValid(object value)
        {
            if (value is string)
            {

                string password = EncryptPassword.encryptPassword(value.ToString());

                if (user.Password == password)
                {
                    return true;
                }

            }
            return false;
        }
    }
}