using BusinessLogic.DomainModels;
using BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Extensions;

namespace DataAccess.Repositories
{
    public class MoviesRepository : RepositoryBase<Models.Movie>, IMoviesRepository
    {
        public MoviesRepository(MoviesContext context) : base(context) { }       
        public List<Movie> GetAll()
        {
            var movies = FindAll(false).ToList();

            var moviesDomain = movies.Select(x => x.ToDomainModel());
            return moviesDomain.ToList();
        }
        public Movie AddUserMovie(Movie movie)
        {
            var movies = FindAll(false).ToList();
            var movieModel = new Models.Movie()
            {

                Name = movie.Name,
                Genre = movie.Genre,
                UserId = movie.UserId,
            };
            Create(movieModel);
            return movieModel.ToDomainModel();
        }
        public List<Movie> GetUserMovies(string id)
        {
            var movies = FindAll(false).ToList();
            var moviesSearched = movies.FindAll(u => u.UserId == id);
            var domainMovies = moviesSearched.Select(m => m.ToDomainModel()).ToList();
            return domainMovies;
        }
    }
}
