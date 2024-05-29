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
    internal class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Value)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Count)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
