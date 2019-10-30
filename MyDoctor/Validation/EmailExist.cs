using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Validation
{
    public class EmailExist :ValidationAttribute
    {

        public static bool flag = false;
        MyDoctorDB.MyDoctorRepository doctor = new MyDoctorDB.MyDoctorRepository();
        public override bool IsValid(object value)
        {
            if(flag)
            {
                return true;
            }
          
            if (value is string)

            {
                string Email = value.ToString();
                MyDoctorDB.MyDoctorRepository doctor = new MyDoctorDB.MyDoctorRepository();
                if(!(doctor.EmailAlreadyRegister(Email)))
                {
                    return false;
                }

            }
            return true;
        }
    }
}