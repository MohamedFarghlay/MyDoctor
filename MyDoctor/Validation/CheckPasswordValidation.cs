using MyDoctor.Models;
using MyDoctor.MyDoctorDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Validation
{
    public class CheckPasswordValidation : ValidationAttribute
    {
        public static User user { get; set; }
        public override bool IsValid(object value)
        {
            if(value is string)
            {
                string UserPassword = value.ToString();

                if (UserPassword.Length < 6)
                {
                    return false;
                }
                string EncryptedUserPassword = EncryptPassword.encryptPassword(UserPassword);
                if (user.Password == EncryptedUserPassword)
                {
                    return true;
                }
            }
            return false;
        }
    }
}