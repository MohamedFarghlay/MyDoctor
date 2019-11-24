namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientAppointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "appointments_ID", "dbo.Appointments");
            DropIndex("dbo.Patients", new[] { "appointments_ID" });
            CreateTable(
                "dbo.PatientAppointments",
                c => new
                    {
                        PatientID = c.Int(nullable: false),
                        AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientID, t.AppointmentID })
                .ForeignKey("dbo.Appointments", t => t.AppointmentID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.AppointmentID);
            
            DropColumn("dbo.Patients", "appointments_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "appointments_ID", c => c.Int());
            DropForeignKey("dbo.PatientAppointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.PatientAppointments", "AppointmentID", "dbo.Appointments");
            DropIndex("dbo.PatientAppointments", new[] { "AppointmentID" });
            DropIndex("dbo.PatientAppointments", new[] { "PatientID" });
            DropTable("dbo.PatientAppointments");
            CreateIndex("dbo.Patients", "appointments_ID");
            AddForeignKey("dbo.Patients", "appointments_ID", "dbo.Appointments", "ID");
        }
    }
}
