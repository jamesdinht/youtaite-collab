using Microsoft.EntityFrameworkCore;

namespace Collab.Models
{
    public class CollabContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CollabContext(DbContextOptions<CollabContext> options) : base(options)
        {   }

    }
}