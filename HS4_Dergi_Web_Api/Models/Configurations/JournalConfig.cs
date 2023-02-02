using HS4_Dergi_Web_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Configurations
{
    public class JournalConfig : IEntityTypeConfiguration<Journal>
    {
        public void Configure(EntityTypeBuilder<Journal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Concessionaire).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.JournalType).IsRequired(true);
            builder.Property(x => x.Period).IsRequired(true);

            builder.HasOne(x => x.Publisher)
                .WithMany(x => x.Journals)
                .HasForeignKey(x => x.PublisherId);

            //builder.HasMany(x => x.JournalSeries)
            //    .WithOne(x => x.Journal);                
        }
    }
}
