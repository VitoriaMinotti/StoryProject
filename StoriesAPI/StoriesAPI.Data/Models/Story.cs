using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesAPI.Infrastructure.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public string Department { get; set; }
        public List<Vote> Votes { get; set; }
    }
}
