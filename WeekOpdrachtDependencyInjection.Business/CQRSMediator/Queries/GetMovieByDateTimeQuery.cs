using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeekOpdrachtDependencyInjection.Core.Entities;
using WeekOpdrachtDependencyInjection.Data.Repositories.SpecificRepositories;

namespace WeekOpdrachtDependencyInjection.Business.CQRSMediator.Queries
{
    public record GetMovieByDateTimeQuery(DateTime DateTime) : IRequest<Result<Movie>>
    {
    }

    public class GetMovieByDateTimeQueryHandler : IRequestHandler<GetMovieByDateTimeQuery, Result<Movie>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetMovieByDateTimeQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Result<Movie>> Handle(GetMovieByDateTimeQuery request, CancellationToken cancellationToken)
        {
            var movie = unitOfWork.MovieRepository.Get(
                filter: m => m.ReleaseDate == request.DateTime
                );
            if (movie == null)
                return Task.FromResult(Result.Failure<Movie>($"Couldn't find a movie with release date: {request.DateTime}"));

            return Task.FromResult(Result.Success(movie));
        }
    }
}
