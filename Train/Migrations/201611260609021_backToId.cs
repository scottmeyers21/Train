namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backToId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Record_RecordId", "dbo.Records");
            RenameColumn(table: "dbo.Cars", name: "Record_RecordId", newName: "Record_Id");
            RenameIndex(table: "dbo.Cars", name: "IX_Record_RecordId", newName: "IX_Record_Id");
            DropPrimaryKey("dbo.Records");
            DropColumn("dbo.Records", "RecordId");
            AddColumn("dbo.Records", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Records", "Id");
            AddForeignKey("dbo.Cars", "Record_Id", "dbo.Records", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Records", "RecordId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Cars", "Record_Id", "dbo.Records");
            DropPrimaryKey("dbo.Records");
            DropColumn("dbo.Records", "Id");
            AddPrimaryKey("dbo.Records", "RecordId");
            RenameIndex(table: "dbo.Cars", name: "IX_Record_Id", newName: "IX_Record_RecordId");
            RenameColumn(table: "dbo.Cars", name: "Record_Id", newName: "Record_RecordId");
            AddForeignKey("dbo.Cars", "Record_RecordId", "dbo.Records", "RecordId");
        }
    }
}
