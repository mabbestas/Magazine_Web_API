using HS4_Dergi_Web_Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Entities
{
    public class JournalSeries
    {
        public int Id { get; set; }
        public string Editor { get; set; }
        public decimal Price { get; set; }
        public int Page { get; set; }
        public DateTime PublicationDate { get; set; }

        // Navigation Prop.
        public int JournalId { get; set; }
        public Journal Journal { get; set; }

        public List<Article> Articles { get; set; }
    }
}
