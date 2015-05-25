namespace VsoApi.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberCapacities",
                c => new
                    {
                        MemberCapacityId = c.Int(nullable: false, identity: true),
                        TeamMemberId = c.Int(nullable: false),
                        SprintId = c.Int(nullable: false),
                        Capacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MemberCapacityId)
                .ForeignKey("dbo.Sprints", t => t.SprintId, cascadeDelete: true)
                .ForeignKey("dbo.TeamMembers", t => t.TeamMemberId, cascadeDelete: true)
                .Index(t => t.TeamMemberId)
                .Index(t => t.SprintId);
            
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        SprintId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SprintId);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        TeamMemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TeamMemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberCapacities", "TeamMemberId", "dbo.TeamMembers");
            DropForeignKey("dbo.MemberCapacities", "SprintId", "dbo.Sprints");
            DropIndex("dbo.MemberCapacities", new[] { "SprintId" });
            DropIndex("dbo.MemberCapacities", new[] { "TeamMemberId" });
            DropTable("dbo.TeamMembers");
            DropTable("dbo.Sprints");
            DropTable("dbo.MemberCapacities");
        }
    }
}
