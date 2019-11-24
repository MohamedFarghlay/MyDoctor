using MyDoctor.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Models
{
    public class UserDeleteInfo
    {
        [ExistUser]
        public int? ID { get; set; }

        [Required(ErrorMessage ="Password Required for this process")]
        [CheckPasswordValidation(ErrorMessage ="Wrong Password, Try Agin")]        
        public string password { get; set; }
    }
}