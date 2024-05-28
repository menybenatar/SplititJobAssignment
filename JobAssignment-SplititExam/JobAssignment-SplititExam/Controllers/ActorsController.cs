using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace JobAssignmentSplititExam.Controllers
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
        [SwaggerResponse(200, "success", Type = typeof(ActorsResponse))]
        [SwaggerResponse(500, "General Error.", Type = typeof(ErrorDetail))]
        public IActionResult GetActors([FromQuery] int? rankStart, [FromQuery] int? rankEnd, [FromQuery] string provider = "IMDb", [FromHeader] int skip = 0, [FromHeader] int take = 10)
        {
            var actors = _actorService.GetActors(provider, rankStart, rankEnd, skip, take);
            var response = new ActorsResponse()
            {
                Actors = actors,
                StatusCode = (int)HttpStatusCode.OK,
                IsSuccess = true,
            };
            return Ok(response);
        }
        [HttpGet]
        [Route("GetActorDetails")]
        [SwaggerResponse(200, "success", Type = typeof(ActorResponse))]
        [SwaggerResponse(204, "Actor Not Found", Type = typeof(ErrorDetail))]
        [SwaggerResponse(500, "General Error.", Type = typeof(ErrorDetail))]

        public IActionResult GetActorDetails(string actorId)
        {
            var actor = _actorService.GetActorDetails(actorId);
            var response = new ActorResponse()
            {
                Actor = actor,
                StatusCode = (int)HttpStatusCode.OK,
                IsSuccess = true,
            };
            return Ok(response);
        }



        [HttpPost]
        [Route("AddActor")]
        [SwaggerResponse(200, "success", Type = typeof(void))]
        [SwaggerResponse(500, "General Error.", Type = typeof(ErrorDetail))]
        public IActionResult AddActor(ActorModel model)
        {
            _actorService.AddActor(model);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateActor")]
        [SwaggerResponse(200, "success", Type = typeof(void))]
        [SwaggerResponse(204, "Actor Not Found", Type = typeof(ErrorDetail))]
        [SwaggerResponse(500, "General Error.", Type = typeof(ErrorDetail))]
        public IActionResult UpdateActor(ActorModel model)
        {
            _actorService.UpdateActor(model);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteActor")]
        [SwaggerResponse(200, "success", Type = typeof(void))]
        [SwaggerResponse(204, "Actor Not Found", Type = typeof(ErrorDetail))]
        [SwaggerResponse(500, "General Error.", Type = typeof(ErrorDetail))]
        public IActionResult DeleteActor(string actorId)
        {
            _actorService.DeleteActor(actorId);
            return Ok();
        }


    }

}
