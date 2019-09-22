namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PatientID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "DoctorID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DoctorID");
            DropColumn("dbo.Users", "PatientID");
        }
    }
}
