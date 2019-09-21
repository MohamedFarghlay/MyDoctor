using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Validation
{
    public class OnlyInt : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is int)
            {
                return true;
            }
            return false;
        }
    }
}