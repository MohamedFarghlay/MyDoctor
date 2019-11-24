namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appointments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientAppointments", "AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.PatientAppointments", "PatientID", "dbo.Patients");
            DropIndex("dbo.PatientAppointments", new[] { "PatientID" });
            DropIndex("dbo.PatientAppointments", new[] { "AppointmentID" });
            AddColumn("dbo.Appointments", "patients_PatientID", c => c.Int());
            CreateIndex("dbo.Appointments", "patients_PatientID");
            AddForeignKey("dbo.Appointments", "patients_PatientID", "dbo.Patients", "PatientID");
            DropTable("dbo.PatientAppointments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PatientAppointments",
                c => new
                    {
                        PatientID = c.Int(nullable: false),
                        AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientID, t.AppointmentID });
            
            DropForeignKey("dbo.Appointments", "patients_PatientID", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "patients_PatientID" });
            DropColumn("dbo.Appointments", "patients_PatientID");
            CreateIndex("dbo.PatientAppointments", "AppointmentID");
            CreateIndex("dbo.PatientAppointments", "PatientID");
            AddForeignKey("dbo.PatientAppointments", "PatientID", "dbo.Patients", "PatientID", cascadeDelete: true);
            AddForeignKey("dbo.PatientAppointments", "AppointmentID", "dbo.Appointments", "ID", cascadeDelete: true);
        }
    }
}
