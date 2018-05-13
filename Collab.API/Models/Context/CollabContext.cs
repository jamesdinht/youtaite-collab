using Collab.API.Models.Config;
using Microsoft.EntityFrameworkCore;

namespace Collab.API.Models.Context
{
    public class CollabContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CollabContext(DbContextOptions<CollabContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
