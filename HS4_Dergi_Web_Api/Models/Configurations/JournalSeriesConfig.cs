using HS4_Dergi_Web_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Configurations
{
    public class JournalSeriesConfig : IEntityTypeConfiguration<JournalSeries>
    {
        public void Configure(EntityTypeBuilder<JournalSeries> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Editor).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Price).IsRequired(true).HasMaxLength(4);
            builder.Property(x => x.Page).IsRequired(true).HasMaxLength(3);
            builder.Property(x => x.PublicationDate).IsRequired(true);

            builder.HasOne(x => x.Journal)
                .WithMany(x => x.JournalSeries)
                .HasForeignKey(x => x.JournalId);

            builder.HasMany(x => x.Articles)
                .WithOne(x => x.JournalSeries);
        }
    }
}
