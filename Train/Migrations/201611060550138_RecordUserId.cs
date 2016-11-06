namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecordUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Records", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Records", new[] { "User_Id" });
            AddColumn("dbo.Records", "UserId", c => c.String());
            DropColumn("dbo.Records", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Records", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Records", "UserId");
            CreateIndex("dbo.Records", "User_Id");
            AddForeignKey("dbo.Records", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
