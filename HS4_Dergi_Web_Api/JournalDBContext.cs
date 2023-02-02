using HS4_Dergi_Web_Api.Models.Configurations;
using HS4_Dergi_Web_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api
{
    public class JournalDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = JournalDb; Trusted_Connection = True; ");
        }
                
        public DbSet<Article> Articles { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalSeries> JournalSeries { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new JournalConfig());
            builder.ApplyConfiguration(new JournalSeriesConfig());
            builder.ApplyConfiguration(new ArticleConfig());
            builder.ApplyConfiguration(new AuthorConfig());
            builder.ApplyConfiguration(new PublisherConfig());


            builder.Entity<Author>().HasData(FakeData.FakeData.GetAuthors(20));
            builder.Entity<Publisher>().HasData(FakeData.FakeData.GetPublishers(20));

            builder.Entity<Journal>().HasData(FakeData.FakeData.GetJournals(20));
            builder.Entity<JournalSeries>().HasData(FakeData.FakeData.GetJournalSeries(20));
            builder.Entity<Article>().HasData(FakeData.FakeData.GetArticles(20));
            


            //this.Journals.AddRange(FakeData.FakeData.GetJournals(20));
            //this.Articles.AddRange(FakeData.FakeData.GetArticles(20));
            //this.Authors.AddRange(FakeData.FakeData.GetAuthors(20));
            //this.JournalSeries.AddRange(FakeData.FakeData.GetJournalSeries(20));
            //this.Publishers.AddRange(FakeData.FakeData.GetPublishers(20));


            base.OnModelCreating(builder);           
        }
    }
}
