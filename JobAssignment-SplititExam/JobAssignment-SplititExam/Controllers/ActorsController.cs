using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobAssignment_SplititExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        [Route("GetActors")]
        public IActionResult GetActors([FromQuery] int? rankStart, [FromQuery] int? rankEnd, [FromQuery] string provider = "IMDb", [FromHeader] int skip = 0, [FromHeader] int take = 10)
        {
            var actors = _actorService.GetActorsSummary(provider, rankStart, rankEnd, skip, take);

            return Ok(actors);
        }

        public IActionResult GetActorDetails(string actorId)
        {
            var actor = _actorService.GetActorDetails(actorId);

            return Ok(actor);
        }
    }

}
