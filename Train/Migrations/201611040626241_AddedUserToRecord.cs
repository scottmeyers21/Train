namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Records", "User_Id");
            AddForeignKey("dbo.Records", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Records", new[] { "User_Id" });
            DropColumn("dbo.Records", "User_Id");
        }
    }
}
