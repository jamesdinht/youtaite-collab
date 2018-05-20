using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config
{
    public class CollaborationConfiguration : IEntityTypeConfiguration<Collaboration>
    {
        public void Configure(EntityTypeBuilder<Collaboration> builder)
        {
            builder.ToTable("Collaborations");

            builder.Property(c => c.Id)
                .HasColumnName("CollaborationId")
                .UseSqlServerIdentityColumn();
        }
    }
}