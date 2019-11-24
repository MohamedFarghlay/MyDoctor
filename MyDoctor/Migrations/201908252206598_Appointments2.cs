namespace MyDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appointments2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "users_ID", "dbo.Users");
            DropIndex("dbo.Appointments", new[] { "users_ID" });
            AddColumn("dbo.Appointments", "PatintID", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "users_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "users_ID", c => c.Int());
            DropColumn("dbo.Appointments", "PatintID");
            CreateIndex("dbo.Appointments", "users_ID");
            AddForeignKey("dbo.Appointments", "users_ID", "dbo.Users", "ID");
        }
    }
}
