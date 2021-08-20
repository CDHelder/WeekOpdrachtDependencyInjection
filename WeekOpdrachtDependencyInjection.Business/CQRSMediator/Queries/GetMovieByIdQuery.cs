using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeekOpdrachtDependencyInjection.Core.Entities;
using WeekOpdrachtDependencyInjection.Data;
using WeekOpdrachtDependencyInjection.Data.Repositories;
using WeekOpdrachtDependencyInjection.Data.Repositories.SpecificRepositories;

namespace WeekOpdrachtDependencyInjection.Business.CQRSMediator.Queries
{
    public record GetMovieByIdQuery(int Id) : IRequest<Result<Movie>>
    {
    }

    public class GetMovieByIdQueryHandlder : IRequestHandler<GetMovieByIdQuery, Result<Movie>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetMovieByIdQueryHandlder(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Result<Movie>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = unitOfWork.MovieRepository.Get(
                filter: m => m.Id == request.Id
                );
            if (movie == null)
                return Task.FromResult(Result.Failure<Movie>($"Couldn't find a movie with id: {request.Id}"));

            return Task.FromResult(Result.Success(movie));
        }
    }
}
