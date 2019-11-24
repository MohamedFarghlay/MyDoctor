using MyDoctor.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.Models
{
    public class UserLogIn
    {
        [Required]
        [EmailAddress(ErrorMessage ="Enter A Valid Email Address")]
        [EmailNotExist(ErrorMessage ="This Email Is Not Registerd")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        //[StringLength(100, ErrorMessage = "The length of Password must be at least 6", MinimumLength = 6)]
        [CheckPassword(ErrorMessage ="Password is wrong, Try Again")]
        public string Password { get; set; }
       
    }
}