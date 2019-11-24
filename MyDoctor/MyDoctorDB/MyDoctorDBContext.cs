using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyDoctor.MyDoctorDB
{
    public class MyDoctorDBContext :DbContext
    {
        //User Table
        public DbSet<User> Users { get; set; }

        //Patient Table
        public DbSet<Patient> Patients { get; set; }

        //Appointment Table
        public DbSet<Appointment> Appointments { get; set; }

       
    }
}