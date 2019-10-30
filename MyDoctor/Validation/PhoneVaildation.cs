using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Validation
{
    public class PhoneVaildation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool flag = false ;
            if(value is string)
            {
                string phone = value.ToString();
                if (phone.ElementAt(0) != '0')
                {
                    return false;
                }

                else {
                    foreach (var item in phone)
                    {
                        if (char.IsDigit(item))
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
                
            }
            return flag;
        }
    }
}