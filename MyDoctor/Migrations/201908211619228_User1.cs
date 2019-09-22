namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PhoneNumner", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "DateOfBirth", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateOfBirth", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumner", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
        }
    }
}
