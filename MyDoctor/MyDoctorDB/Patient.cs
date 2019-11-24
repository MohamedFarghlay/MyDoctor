using MyDoctor.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDoctor.MyDoctorDB
{
    public class Patient
    {
        [Key]
        [OnlyInt(ErrorMessage ="This Valid Must accept only integers")]
        public int PatientID { get; set; }

        public User users { get; set; }

   
    }
}