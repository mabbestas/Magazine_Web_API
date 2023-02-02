using HS4_Dergi_Web_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Configurations
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired(true).HasMaxLength(30);

            builder.HasMany(x => x.Articles)
                 .WithOne(x => x.Author);
        }
    }
}
