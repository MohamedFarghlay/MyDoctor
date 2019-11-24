using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDoctor.MyDoctorDB
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Date Of Appointment")]
        public string DateOfAppointment { get; set; }

        [Display(Name ="Doctor Name")]
        public string DoctorName { get; set; }

        public int PatintID { get; set; }

        //relationship with  Patient 
        //public Patient patients { get; set; }
        //public User users { get; set; }


    }
}