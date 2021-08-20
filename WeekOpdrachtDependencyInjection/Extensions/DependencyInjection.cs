using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtDependencyInjection.Business;
using WeekOpdrachtDependencyInjection.Business.Interfaces;
using WeekOpdrachtDependencyInjection.Data.Repositories;
using WeekOpdrachtDependencyInjection.Data.Repositories.SpecificRepositories;

namespace WeekOpdrachtDependencyInjection.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureAllDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<ICalculatePiService, CalculatePiService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
