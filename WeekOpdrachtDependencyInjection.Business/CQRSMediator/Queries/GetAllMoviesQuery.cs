using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtDependencyInjection.Core.Entities;

namespace WeekOpdrachtDependencyInjection.Business.CQRSMediator.Queries
{
    public record GetAllMoviesQuery(DateTime? DateTime, string title = "") : IRequest<Result<ICollection<Movie>>>
    {
    }

    //TODO: Implement
}
