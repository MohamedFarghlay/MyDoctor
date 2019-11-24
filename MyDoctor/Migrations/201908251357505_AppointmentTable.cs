namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateOfAppointment = c.String(),
                        DoctorName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Patients", "appointments_ID", c => c.Int());
            CreateIndex("dbo.Patients", "appointments_ID");
            AddForeignKey("dbo.Patients", "appointments_ID", "dbo.Appointments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "appointments_ID", "dbo.Appointments");
            DropIndex("dbo.Patients", new[] { "appointments_ID" });
            DropColumn("dbo.Patients", "appointments_ID");
            DropTable("dbo.Appointments");
        }
    }
}
