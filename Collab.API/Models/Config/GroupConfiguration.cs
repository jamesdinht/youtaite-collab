using Collab.API.Models.Config.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups")
                .HasMany(g => g.Users);

            builder.Property(g => g.Id)
                .HasColumnName("GroupId")
                .UseSqlServerIdentityColumn();

            builder.AddDateCreatedColumn();
            builder.AddLastUpdatedColumn();
        }
    }
}