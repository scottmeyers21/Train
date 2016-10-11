namespace Train.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Train.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Train.Models.ApplicationDbContext context)
        {
            //    var car = new Cars[]
            //        {
            //            new Cars {Id = 1,Name = "Car1"},
            //            new Cars {Id = 2,Name = "Car2"}


            //            };

            //    //  This method will be called after migrating to the latest version.

            //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //    //  to avoid creating duplicate seed data. E.g.
            //    //
            //    //    context.People.AddOrUpdate(
            //    //      p => p.FullName,
            //    //      new Person { FullName = "Andrew Peters" },
            //    //      new Person { FullName = "Brice Lambson" },
            //    //      new Person { FullName = "Rowan Miller" }
            //    //    );
            //    //
        }
    }
}
