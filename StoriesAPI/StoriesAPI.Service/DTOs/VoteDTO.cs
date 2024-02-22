using StoriesAPI.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesAPI.Service.DTOs
{
    public class VoteDTO
    {
        public int Id { get; set; }
        public bool Like { get; set; }
        public int StoryId { get; set; }
        public int UserID { get; set; }
    }
}
