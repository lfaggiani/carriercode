namespace CarrierProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserConstraint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRating", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.UserRating", new[] { "ApplicationUserID" });
            AlterColumn("dbo.UserRating", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserRating", "ApplicationUserID");
            AddForeignKey("dbo.UserRating", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRating", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.UserRating", new[] { "ApplicationUserID" });
            AlterColumn("dbo.UserRating", "ApplicationUserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UserRating", "ApplicationUserID");
            AddForeignKey("dbo.UserRating", "ApplicationUserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
