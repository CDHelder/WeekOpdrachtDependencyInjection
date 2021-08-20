using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeekOpdrachtDependencyInjection.Business.CQRSMediator.Queries;

namespace WeekOpdrachtDependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator mediator;

        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetMovieByIdQuery(id));

            if (response.IsFailure)
                return NotFound(response.Error);

            return Ok(response.Value);
        }

        //Waarom heb je meerdere HttpGets nodig, kan ook in een
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllMoviesQuery query)
        {
            var response = await mediator.Send(query);

            return Ok(response.Value);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] string title)
        //{
        //    var response = await mediator.Send(new GetMovieByTitleQuery(title));

        //    if (response.IsFailure)
        //        return NotFound(response.Error);

        //    return Ok(response.Value);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] DateTime dateTime)
        //{
        //    var response = await mediator.Send(new GetMovieByDateTimeQuery(dateTime));

        //    if (response.IsFailure)
        //        return NotFound(response.Error);

        //    return Ok(response.Value);
        //}
    }
}
