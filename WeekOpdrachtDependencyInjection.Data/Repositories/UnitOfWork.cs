using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtDependencyInjection.Data.Repositories.SpecificRepositories;

namespace WeekOpdrachtDependencyInjection.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private MovieRepository movieRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public MovieRepository MovieRepository
        {
            get => movieRepository ?? new MovieRepository(dbContext);

            private set => movieRepository = value;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Result SaveChanges()
        {
            var rowsChanged = dbContext.SaveChanges();
            if (rowsChanged > 0)
                return Result.Success();

            return Result.Failure("No changes were made in the database");
        }
    }
}
