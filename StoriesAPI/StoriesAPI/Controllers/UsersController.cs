using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoriesAPI.Request;
using StoriesAPI.Service;
using StoriesAPI.ViewModels;
using System.Net;

namespace StoriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [ProducesResponseType((typeof(UserRequest)), (int)HttpStatusCode.OK)]
        [ProducesResponseType((typeof(UserRequest)), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((typeof(UserRequest)), (int)HttpStatusCode.BadRequest)]
        public ActionResult<List<StoryViewModel>> GetAll()
        {
            var users = _usersService.GetAll();
            return Ok(users);
        }
    }
}
