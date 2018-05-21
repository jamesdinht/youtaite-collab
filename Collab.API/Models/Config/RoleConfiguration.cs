using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles")
                .HasKey(r => r.Id);

            builder.HasMany(r => r.UserRoles);

            builder.Property(r => r.Id)
                .HasColumnName("RoleId")
                .ValueGeneratedNever();

            builder.Property(r => r.RoleName)
                .HasColumnName("Role")
                .IsRequired();
        }
    }
}