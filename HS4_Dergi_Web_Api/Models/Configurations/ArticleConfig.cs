using HS4_Dergi_Web_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Configurations
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired(true).HasMaxLength(1000);
            builder.Property(x => x.Image).IsRequired(false);

            builder.HasOne(x => x.JournalSeries)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.JournalSeriesId);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}
