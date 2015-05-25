namespace VsoApi.Backend.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Add_Sprint_Support_Days : DbMigration
    {
        public override void Up()
        {
            AddColumn(
                "Sprints",
                "SupportDays",
                c => c.Int(false, false, 10));

            Sql("UPDATE Sprints SET SupportDays = 9 where Name = 'Sprint 45'");
            Sql("UPDATE Sprints SET SupportDays = 8 where Name = 'Sprint 46'");
            Sql("UPDATE Sprints SET SupportDays = 9 where Name = 'Sprint 58'");
        }

        public override void Down()
        {
            DropColumn("Sprints", "SupportDays");
        }
    }
}