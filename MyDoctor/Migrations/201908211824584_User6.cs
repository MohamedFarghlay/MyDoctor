namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PhoneNumner", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PhoneNumner", c => c.String(nullable: false));
        }
    }
}
