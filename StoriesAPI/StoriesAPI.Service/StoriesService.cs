using StoriesAPI.Service.DTOs;
using StoriesAPI.Infrastructure.Data;
using StoriesAPI.Infrastructure.Models;

namespace StoriesAPI.Service
{
    public interface IStoriesService
    {
        bool Add(string Title, string Description, string Department);
        bool Update(int id, string Title, string Description, string Department);
        bool Delete(int id);
        StoryDTO GetById(int id);
        List<StoryDTO> GetAll();
    }

    public class StoriesService : IStoriesService
    {
        private readonly MyDatabase _dbContext;
        public StoriesService(MyDatabase myDatabase)
        {
            _dbContext = myDatabase;
        }

        StoryDTO IStoriesService.GetById(int id)
        {
            return _dbContext.Stories.Select(s => new StoryDTO() { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(x => x.Like), Dislikes = s.Votes.Count(x => !x.Like) }).FirstOrDefault(c => c.Id == id);
        }

        List<StoryDTO> IStoriesService.GetAll()
        {
            return _dbContext.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(x => x.Like), Dislikes = s.Votes.Count(x => !x.Like)}).ToList();
        }

        bool IStoriesService.Add(string title, string description, string department)
        {
            _dbContext.Stories.Add(new Story { Title = title, Description = description, Department = department });

            return _dbContext.SaveChanges() > 0;
        }

        bool IStoriesService.Update(int id, string title, string description, string department)
        {
            var storyById = _dbContext.Stories.FirstOrDefault(x => x.Id == id);

            storyById.Title = title;
            storyById.Description = description;
            storyById.Department = department;

            _dbContext.Stories.Update(storyById);
            _dbContext.SaveChanges();

            return true;
        }

        bool IStoriesService.Delete(int id)
        {
            Story storyById = _dbContext.Stories.FirstOrDefault(c => c.Id == id);

            if (storyById == null)
            {
                throw new Exception("A story com o ID {id} não foi encontrado.");
            }

            _dbContext.Stories.Remove(storyById);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
