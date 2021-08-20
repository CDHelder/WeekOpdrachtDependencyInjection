using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WeekOpdrachtDependencyInjection.Core.Entities;
using WeekOpdrachtDependencyInjection.Data.Repositories.SpecificRepositories;

namespace WeekOpdrachtDependencyInjection.Business.CQRSMediator.Queries
{
    public record GetMovieByTitleQuery(string Title) : IRequest<Result<Movie>>
    {
    }

    public class GetMovieByTitleQueryHandler : IRequestHandler<GetMovieByTitleQuery, Result<Movie>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetMovieByTitleQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Result<Movie>> Handle(GetMovieByTitleQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return Task.FromResult(Result.Failure<Movie>($"Please enter a valid movie title"));

            var movie = unitOfWork.MovieRepository.Get(
                filter: m => m.Title == request.Title
                );
            if (movie == null)
                return Task.FromResult(Result.Failure<Movie>($"Couldn't find a movie with title: {request.Title}"));

            return Task.FromResult(Result.Success(movie));
        }
    }
}
