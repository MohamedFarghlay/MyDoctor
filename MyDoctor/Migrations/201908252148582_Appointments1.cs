namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appointments1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "patients_PatientID", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "patients_PatientID" });
            AddColumn("dbo.Appointments", "users_ID", c => c.Int());
            CreateIndex("dbo.Appointments", "users_ID");
            AddForeignKey("dbo.Appointments", "users_ID", "dbo.Users", "ID");
            DropColumn("dbo.Appointments", "patients_PatientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "patients_PatientID", c => c.Int());
            DropForeignKey("dbo.Appointments", "users_ID", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "users_ID" });
            DropColumn("dbo.Appointments", "users_ID");
            CreateIndex("dbo.Appointments", "patients_PatientID");
            AddForeignKey("dbo.Appointments", "patients_PatientID", "dbo.Patients", "PatientID");
        }
    }
}
