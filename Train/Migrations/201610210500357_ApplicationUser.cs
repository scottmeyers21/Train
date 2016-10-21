namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Company", c => c.String(maxLength: 250));
            CreateIndex("dbo.Cars", "ApplicationUser_Id");
            AddForeignKey("dbo.Cars", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.AspNetUsers", "Company", c => c.String());
            DropColumn("dbo.Cars", "ApplicationUser_Id");
        }
    }
}
