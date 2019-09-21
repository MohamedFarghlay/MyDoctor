using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MyDoctor.Validation
{
    public class PasswordValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool IsValidPass = false;
            if(value is string)
            {
                string password = value.ToString();
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");

                bool isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password);
               

                IsValidPass = isValidated;
            }
            return IsValidPass;
        }
    }
}