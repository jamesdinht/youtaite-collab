using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasMany(u => u.Groups);

            builder.HasMany(u => u.Roles);

            builder.Property(u => u.Id)
                .HasColumnName("UserId")
                .UseSqlServerIdentityColumn();
        }
    }
}