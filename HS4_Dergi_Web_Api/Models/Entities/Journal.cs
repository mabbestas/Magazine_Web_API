using HS4_Dergi_Web_Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Entities
{
    public class Journal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Concessionaire { get; set; }

        public JournalType JournalType { get; set; }
        public Period Period { get; set; }

        // Navigation Prop.
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<JournalSeries> JournalSeries { get; set; }
    }
}
