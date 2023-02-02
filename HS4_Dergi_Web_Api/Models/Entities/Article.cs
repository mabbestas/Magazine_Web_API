using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        // Navigation Prop
        public int JournalSeriesId { get; set; }
        public JournalSeries JournalSeries { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
