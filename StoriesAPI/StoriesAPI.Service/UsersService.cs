using StoriesAPI.Service.DTOs;
using StoriesAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace StoriesAPI.Service
{
    public interface IUsersService
    {
        List<UserDTO> GetAll();
    }

    public class UsersService : IUsersService
    {
        private readonly MyDatabase _dbContext;

        public UsersService(MyDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public List<UserDTO> GetAll()
        {
            return _dbContext.Users.Select(s => new UserDTO { Id = s.Id, Name = s.Name }).ToList();
        }
    }
}
