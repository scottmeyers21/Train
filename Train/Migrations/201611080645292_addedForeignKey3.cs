namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKey4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Record_Id", "dbo.Records");
            DropIndex("dbo.Cars", new[] { "Record_Id" });
            DropPrimaryKey("dbo.Records");
            DropColumn("dbo.Cars", "RecordId");
            DropColumn("dbo.Records", "Id");
            RenameColumn(table: "dbo.Cars", name: "Record_Id", newName: "RecordRefId");
            AddColumn("dbo.Records", "RecordId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cars", "RecordRefId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Records", "RecordId");
            CreateIndex("dbo.Cars", "RecordRefId");
            AddForeignKey("dbo.Cars", "RecordRefId", "dbo.Records", "RecordId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Records", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cars", "RecordId", c => c.String());
            DropForeignKey("dbo.Cars", "RecordRefId", "dbo.Records");
            DropIndex("dbo.Cars", new[] { "RecordRefId" });
            DropPrimaryKey("dbo.Records");
            AlterColumn("dbo.Cars", "RecordRefId", c => c.Int());
            DropColumn("dbo.Records", "RecordId");
            AddPrimaryKey("dbo.Records", "Id");
            RenameColumn(table: "dbo.Cars", name: "RecordRefId", newName: "Record_Id");
            CreateIndex("dbo.Cars", "Record_Id");
            AddForeignKey("dbo.Cars", "Record_Id", "dbo.Records", "Id");
        }
    }
}
