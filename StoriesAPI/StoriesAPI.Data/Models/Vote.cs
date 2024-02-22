using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesAPI.Infrastructure.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public bool Like { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Story Story { get; set; }
        public int StoryId { get; set; } 
    }
}
