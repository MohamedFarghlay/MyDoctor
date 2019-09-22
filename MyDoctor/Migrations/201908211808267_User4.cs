namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PatientID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "DoctorID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DoctorID", c => c.Int());
            AlterColumn("dbo.Users", "PatientID", c => c.Int());
        }
    }
}
