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
    internal class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Price)
                .WithMany()
                .HasForeignKey(x => x.PriceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Color)
                .WithMany()
                .HasForeignKey(x => x.ColorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x =>x.Count)
                .IsRequired()
                .HasDefaultValue(0);

        }
    }
}
