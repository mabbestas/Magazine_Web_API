using Bogus;
using HS4_Dergi_Web_Api.Models.Entities;
using HS4_Dergi_Web_Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.FakeData
{
    public class FakeData
    {
        private static List<Journal> _journals;
        private static List<JournalSeries> _journalSeries;
        private static List<Article> _articles;
        private static List<Author> _authors;
        private static List<Publisher> _publishers;

        public static List<Journal> GetJournals(int number)
        {
            if (_journals == null)
            {
                _journals = new Faker<Journal>()
                    .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                    .RuleFor(x => x.Name, f => f.Name.FirstName())
                    .RuleFor(x => x.Concessionaire, f => f.Name.FullName())
                    .RuleFor(x => x.JournalType, f => (JournalType)f.Random.Number(1, 6))
                    .RuleFor(x => x.Period, f => (Period)f.Random.Number(1, 5))
                    .RuleFor(x => x.PublisherId, f => f.Random.Number(1, 20))
                    .Generate(number);
            }
            return _journals;
        }

        public static List<JournalSeries> GetJournalSeries(int number)
        {
            if (_journalSeries == null)
            {
                _journalSeries = new Faker<JournalSeries>()
                    .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                    .RuleFor(x => x.Editor, f => f.Name.FullName())
                    .RuleFor(x => x.Price, 10)
                    .RuleFor(x => x.Page, f => f.Random.Number(30, 100))
                    .RuleFor(x => x.JournalId, f => f.Random.Number(1,20))
                    .Generate(number);
            }
            return _journalSeries;
        }

        public static List<Article> GetArticles(int number)
        {
            if (_articles == null)
            {
                _articles = new Faker<Article>()
                    .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                    .RuleFor(x => x.Title, f => f.Name.JobTitle())
                    .RuleFor(x => x.Description, f => f.Name.JobDescriptor())
                    .RuleFor(x => x.AuthorId, f => f.Random.Number(1,20))
                    .RuleFor(x => x.JournalSeriesId, f => f.Random.Number(1,20))
                    .Generate(number);
            }
            return _articles;
        }

        public static List<Author> GetAuthors(int number)
        {
            if (_authors == null)
            {
                _authors = new Faker<Author>()
                    .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                    .RuleFor(x => x.FullName, f => f.Name.FullName())
                    .Generate(number);
            }
            return _authors;
        }

        public static List<Publisher> GetPublishers(int number)
        {
            if (_publishers == null)
            {
                _publishers = new Faker<Publisher>()
                    .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                    .RuleFor(x => x.Name, f => f.Name.FullName())
                    .Generate(number);
            }
            return _publishers;
        }
    }
}
