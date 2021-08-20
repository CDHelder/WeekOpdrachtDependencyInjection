using WeekOpdrachtDependencyInjection.Core.Entities;

namespace WeekOpdrachtDependencyInjection.Business.Interfaces
{
    public interface IMovieService
    {
        public Movie Get(int id);
        public Movie Get(string title);
    }
}
