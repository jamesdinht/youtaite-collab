using Collab.API.Models.Config.Extensions;
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

            builder.Ignore(gm => gm.Id);

            builder.HasOne(gm => gm.User)
                .WithMany(u => u.Groups)
                .HasForeignKey(gm => gm.UserId);

            builder.HasOne(gm => gm.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(gm => gm.GroupId);

            builder.AddDateCreatedColumn();
            builder.AddLastUpdatedColumn();
        }
    }
}