using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS4_Dergi_Web_Api.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        // Navigation Prop
        public List<Article> Articles { get; set; }
    }
}
