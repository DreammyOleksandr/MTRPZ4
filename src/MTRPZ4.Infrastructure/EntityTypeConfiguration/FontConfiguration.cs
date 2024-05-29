using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTRPZ4.CoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Infrastructure.EntityTypeConfiguration
{
    internal class FontConfiguration : IEntityTypeConfiguration<Font>
    {
        public void Configure(EntityTypeBuilder<Font> builder)
        {
            builder.HasKey(x => x.Id);

           builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x =>x.Count)
                .IsRequired()
                .HasDefaultValue(0);

        }
    }
}
