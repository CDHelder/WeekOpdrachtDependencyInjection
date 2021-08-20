using MediatR;
using WeekOpdrachtDependencyInjection.Business.Interfaces;
using WeekOpdrachtDependencyInjection.Core.Entities;

namespace WeekOpdrachtDependencyInjection.Business
{
    public class MovieService : IMovieService
    {
        private readonly IMediator mediator;

        public MovieService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Movie Get(int id)
        {
            //return mediator.Send(new GetMovieByIdQuery(id)).Result.Value;
            return null;
        }

        public Movie Get(string title)
        {
            //return mediator.Send(new GetMovieByIdQuery(title)).Result.Value;
            return null;
        }
    }
}
