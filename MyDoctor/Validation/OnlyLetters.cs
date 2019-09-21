using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Validation
{
    public class OnlyLetters : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            bool flag = false;
            if (value is string)
            {
                string Name = value.ToString();

                foreach (var item in Name)
                {
                    if (char.IsLetter(item))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }


            }
            return flag;
        }
    }
}