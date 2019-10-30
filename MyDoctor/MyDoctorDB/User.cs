using MyDoctor.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDoctor.MyDoctorDB
{
    public enum Gender
    {
        Male,Female
    }

   
    public class User
    {
        //ID Vaildation 
        [Key]
        public int ID { get; set; }

        //Firat Name Validation
        [Required(ErrorMessage ="First Name is required")]
        [StringLength(50,ErrorMessage ="First Name Must Be at least 3 Characters" ,MinimumLength =3)]
        [OnlyLetters(ErrorMessage ="First Name Contain letters only")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        //Last Name
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name Must Be at least 3 Characters", MinimumLength = 3)]
        [OnlyLetters(ErrorMessage = "Last Name Must Contain Letters Only")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        //Email Vaildation
        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage ="Please, Enter A Valid Email Address")]
        [EmailExist(ErrorMessage = "This Email Address is Already Registerd !\n Try Another One..")]
        public string Email { get; set; }

        //Phone Number Validation
        [Required(ErrorMessage ="Phone Number Is Required")]
        [StringLength(11,ErrorMessage ="Phone number Must be 11 numbers",MinimumLength =11)]
        [PhoneVaildation(ErrorMessage ="Phone Can't Contain Letters, Only Digit and start with 0")]
        [DisplayName("Phone Number")]
        public string PhoneNumner { get; set; }

        //Password Validation
        [Required(ErrorMessage ="Password is Required")]
        //[PasswordValidation(ErrorMessage ="Password Must Contains Capital, Small Letters,  And Numbers")]
        [StringLength(100,ErrorMessage ="The length of Password must be at least 6",MinimumLength =6)]
        public string Password { get; set; }

        //Gender Validation
        [Required(ErrorMessage ="Please, Spcify Your Gender")]
        public Gender gender { get; set; }

        //Date Of Birth Validation
        [Required(ErrorMessage ="Your Birth Of Date Required")]
        [DisplayName("Your Date Of Birth")]
        public string DateOfBirth { get; set; }
        
        public byte[] Image { get; set; }

        [OnlyInt]
        public int PatientID { get; set; }

        [OnlyInt]
        public int DoctorID { get; set; }
    }
}