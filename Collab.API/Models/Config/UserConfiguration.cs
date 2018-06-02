using System.Collections.Generic;
using Collab.API.Models.Config.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Id)
                .HasColumnName("UserId")
                .UseSqlServerIdentityColumn();
                
            builder.AddDateCreatedColumn();
            builder.AddLastUpdatedColumn();
        }
    }
}