using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Prop
        public List<Journal> Journals { get; set; }
    }
}
