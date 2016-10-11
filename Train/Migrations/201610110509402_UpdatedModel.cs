namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Company", c => c.String());
            AddColumn("dbo.Cars", "EmptyOrLoaded", c => c.String());
            AddColumn("dbo.Cars", "CarType", c => c.String());
            AddColumn("dbo.Cars", "ShippedBy", c => c.String());
            AddColumn("dbo.Cars", "RailcarNumber", c => c.String());
            DropColumn("dbo.Cars", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Name", c => c.String());
            DropColumn("dbo.Cars", "RailcarNumber");
            DropColumn("dbo.Cars", "ShippedBy");
            DropColumn("dbo.Cars", "CarType");
            DropColumn("dbo.Cars", "EmptyOrLoaded");
            DropColumn("dbo.Cars", "Company");
        }
    }
}
