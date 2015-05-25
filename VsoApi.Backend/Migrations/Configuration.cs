namespace VsoApi.Backend.Migrations
{
    using System.Data.Entity.Migrations;
    using VsoApi.Backend.DataAccess;

    internal sealed class Configuration : DbMigrationsConfiguration<VsoApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "VsoApi.Backend.DataAccess.VsoApiContext";
        }

        protected override void Seed(VsoApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}