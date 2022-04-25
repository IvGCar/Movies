using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IMoviesRepository
    {
        public List<DomainModels.Movie> GetAll();
        public DomainModels.Movie AddUserMovie(DomainModels.Movie movie);
        public List<DomainModels.Movie> GetUserMovies(DomainModels.User user);

    }
}
