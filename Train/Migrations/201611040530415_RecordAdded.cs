namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecordAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "RecordId", c => c.String());
            AddColumn("dbo.Cars", "Record_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Record_Id");
            AddForeignKey("dbo.Cars", "Record_Id", "dbo.Records", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Record_Id", "dbo.Records");
            DropIndex("dbo.Cars", new[] { "Record_Id" });
            DropColumn("dbo.Cars", "Record_Id");
            DropColumn("dbo.Cars", "RecordId");
            DropTable("dbo.Records");
        }
    }
}
