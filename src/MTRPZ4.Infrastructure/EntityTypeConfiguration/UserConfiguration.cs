using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTRPZ4.CoreDomain.Entities;

namespace MTRPZ4.Infrastructure.EntityTypeConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(u => u.Email)
                .IsRequired(true);

            builder.Property(u => u.UserName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(u => u.PasswordHash)
                .IsRequired(true);

            builder.Property(u => u.IfCompletedTest)
                .HasDefaultValue(false);
        }
    }
}
