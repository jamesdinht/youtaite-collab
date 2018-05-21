using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config
{
    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.ToTable("GroupMembers")
                .HasKey(gm => new { gm.GroupId, gm.UserId });

            builder.Property(gm => gm.Id)
                .HasColumnName("GroupMemberId")
                .ValueGeneratedOnAdd();
        }
    }
}