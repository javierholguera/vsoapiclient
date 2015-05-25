namespace VsoApi.Backend.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.ModelConfiguration;
    using VsoApi.Backend.DomainModel;
    using VsoApi.Backend.Migrations;

    public interface IVsoApiContext
    {
        IDbSet<Sprint> Sprints { get; set; }
        IDbSet<TeamMember> TeamMembers { get; set; }
        IDbSet<MemberCapacity> MemberCapacities { get; set; }

        void Save();
    }

    public class VsoApiContext : DbContext, IVsoApiContext
    {
        public VsoApiContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VsoApiContext, Configuration>());
        }

        public VsoApiContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VsoApiContext, Configuration>()); 
        }

        public IDbSet<Sprint> Sprints { get; set; }
        public IDbSet<TeamMember> TeamMembers { get; set; }
        public IDbSet<MemberCapacity> MemberCapacities { get; set; }
        public void Save()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new SprintMapping());
            modelBuilder.Configurations.Add(new MemberCapacityMapping());
            modelBuilder.Configurations.Add(new TeamMemberMapping());
        }
    }

    public class SprintMapping : EntityTypeConfiguration<Sprint>
    {
        public SprintMapping()
        {
            HasMany(sprint => sprint.MemberCapacities)
                .WithRequired(memberCapacity => memberCapacity.Sprint)
                .HasForeignKey(memberCapacity => memberCapacity.SprintId)
                .WillCascadeOnDelete(true);
        }
    }

    public class MemberCapacityMapping : EntityTypeConfiguration<MemberCapacity>
    {
        public MemberCapacityMapping()
        {
            HasRequired(memberCapacity => memberCapacity.TeamMember)
                .WithMany(teamMember => teamMember.Capacities)
                .HasForeignKey(memberCapacity => memberCapacity.TeamMemberId);

            HasRequired(memberCapacity => memberCapacity.Sprint)
                .WithMany(teamMember => teamMember.MemberCapacities)
                .HasForeignKey(memberCapacity => memberCapacity.SprintId);
        }
    }

    public class TeamMemberMapping : EntityTypeConfiguration<TeamMember>
    {
        public TeamMemberMapping()
        {
            HasMany(sprint => sprint.Capacities)
                .WithRequired(memberCapacity => memberCapacity.TeamMember)
                .HasForeignKey(memberCapacity => memberCapacity.TeamMemberId)
                .WillCascadeOnDelete(true);
        }
    }
}