using System;
using System.Threading;
using System.Threading.Tasks;
using Collab.API.Models.Config;
using Microsoft.EntityFrameworkCore;

namespace Collab.API.Models.Context
{
    public class CollabContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public CollabContext(DbContextOptions<CollabContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("collab");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new GroupMemberConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
         CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        // Automatically insert values for date created and last updated date
        // Reference: https://www.meziantou.net/2017/07/03/entity-framework-core-generate-tracking-columns
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                var now = DateTime.Now;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["DateCreated"] = now;
                        break;

                    case EntityState.Modified:
                        entry.CurrentValues["DateLastUpdated"] = now;
                        break;
                }
            }
        }
    }
}
