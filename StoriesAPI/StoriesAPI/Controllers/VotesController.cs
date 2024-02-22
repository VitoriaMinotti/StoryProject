using Microsoft.AspNetCore.Mvc;
using StoriesAPI.Service;
using StoriesAPI.Service.DTOs;
using System.Net;

namespace StoriesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : Controller
    {
        private readonly IVotesService _votesService;

        public VotesController(IVotesService votesService)
        {
            _votesService = votesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<VoteDTO>),(int)HttpStatusCode.OK)]
        public IActionResult GetAll() 
        {
            return Ok(_votesService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Add(bool Like, int UserID, int StoryID)
        {
            _votesService.Add(Like, UserID, StoryID);

            return Ok ();

        }
    }
}
