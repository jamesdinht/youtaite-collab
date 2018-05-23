using Collab.API.Models.Config.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ProjectId");

            builder.Property(p => p.ProjectName)
                .IsRequired();

            builder.HasOne(p => p.Group)
                .WithOne(g => g.Project)
                .HasForeignKey<Group>(g => g.ProjectId);

            builder.AddDateCreatedColumn();
            builder.AddLastUpdatedColumn();
        }
    }
}