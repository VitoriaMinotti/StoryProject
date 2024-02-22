using StoriesAPI.Service.DTOs;
using StoriesAPI.Infrastructure.Data;
using StoriesAPI.Infrastructure.Models;

namespace StoriesAPI.Service
{
    public interface IVotesService
    {
        bool Add(bool Like, int UserID, int StoryID);
        List<VoteDTO> GetAll ();
    }

    public class VotesService : IVotesService
    {
        private readonly MyDatabase _dbContext;
        public VotesService(MyDatabase myDatabase)
        {
            _dbContext = myDatabase;
        }

        public bool Add(bool Like, int UserID, int StoryID)
        {
            _dbContext.Votes.Add(new Vote {Like = Like, UserId = UserID, StoryId = StoryID});

            return _dbContext.SaveChanges() > 0;
        }

        public List<VoteDTO> GetAll()
        {
            return _dbContext.Votes.Select(s => new VoteDTO { Id = s.Id, Like = s.Like, UserID = s.UserId, StoryId = s.StoryId}).ToList();
        }
    }
}
