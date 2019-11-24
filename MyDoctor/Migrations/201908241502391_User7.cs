namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Users", "PhoneNumner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PhoneNumner", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Users", "PhoneNumber");
        }
    }
}
