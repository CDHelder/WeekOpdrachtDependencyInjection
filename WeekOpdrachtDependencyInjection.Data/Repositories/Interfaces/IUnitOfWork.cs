using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtDependencyInjection.Data.Repositories.SpecificRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        public MovieRepository MovieRepository { get; }
        Result SaveChanges();
    }
}
