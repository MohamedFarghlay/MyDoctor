namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        users_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.Users", t => t.users_ID)
                .Index(t => t.users_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        PhoneNumner = c.String(),
                        Password = c.String(),
                        gender = c.Int(nullable: false),
                        DateOfBirth = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "users_ID", "dbo.Users");
            DropIndex("dbo.Patients", new[] { "users_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Patients");
        }
    }
}
