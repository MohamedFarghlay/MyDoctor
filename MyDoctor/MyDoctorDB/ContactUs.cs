using MyDoctor.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDoctor.MyDoctorDB
{
    public class ContactUs
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [OnlyLetters(ErrorMessage ="Name Must Be Contain Letter Only")]
        [StringLength(50, ErrorMessage = "First Name Must Be at least 3 Characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Please, Enter A Valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject Is Required")]
        //[OnlyLetters(ErrorMessage = "Subject Must Be Contain Letter Only")]
        [StringLength(50, ErrorMessage = "Subject Must Be at least 3 Characters", MinimumLength = 3)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message Is Required")]
        //[OnlyLetters(ErrorMessage = "Message Must Be Contain Letter Only")]
        [StringLength(int.MaxValue, ErrorMessage = "Message Must Be at least 5 Characters", MinimumLength = 5)]
        public string  Message { get; set; }
    }
   


}