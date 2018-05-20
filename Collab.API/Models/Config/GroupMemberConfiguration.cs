using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config
{
    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.ToTable("Collaborations");

            builder.Property(c => c.Id)
                .HasColumnName("CollaborationId")
                .UseSqlServerIdentityColumn();
        }
    }
}