namespace Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCompany : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "Company");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Company", c => c.String());
        }
    }
}
