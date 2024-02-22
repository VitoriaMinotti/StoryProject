using Microsoft.AspNetCore.Mvc;
using StoriesAPI.Request;
using StoriesAPI.Service;
using StoriesAPI.Service.DTOs;
using StoriesAPI.ViewModels;
using System.Net;

namespace StoriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : Controller
    {
        private readonly IStoriesService _storiesService;
        public StoriesController(IStoriesService storiesService)
        {
            _storiesService = storiesService;
        }

        [HttpGet]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.OK)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.BadRequest)]
        public ActionResult<List<StoryViewModel>> GetAll()
        {
            var stories =  _storiesService.GetAll();
            return Ok(stories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.OK)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.BadRequest)]
        public ActionResult<StoryViewModel> GetById(int id)
        {
            StoryDTO stories = _storiesService.GetById(id);
            return Ok(stories);
        }

        [HttpPost]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.OK)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.BadRequest)]
        public ActionResult<StoryViewModel> Add([FromBody] StoryRequest storyViewModel)
        {

            _storiesService.Add(storyViewModel.Title, storyViewModel.Description, storyViewModel.Department);

            return Ok(storyViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.OK)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.BadRequest)]
        public ActionResult<StoryViewModel> Update([FromBody] StoryRequest storyViewModel, int id)
        {
            _storiesService.Update(id, storyViewModel.Title, storyViewModel.Description, storyViewModel.Department);

            return Ok(storyViewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.OK)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((typeof(StoryRequest)), (int)HttpStatusCode.BadRequest)]
        public ActionResult<StoryViewModel> Delete(int id)
        {

            bool deleted = _storiesService.Delete(id);

            return Ok(deleted);
        }
    }
}
