using BusinessLogic.Interfaces;
using System.Collections.Generic;
using DTO;
using System.Linq;
using BusinessLogic.Extensions;

namespace BusinessLogic.Services
{
    public class MoviesService
    {
        private readonly IRepositoryManager _repositoryManager;

        public MoviesService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<Movie> GetMovies()
        {
            return _repositoryManager.Movies.GetAll().Select(x => new Movie()
            {
                Name = x.Name,
                Genre = x.Genre,
                Id = x.Id,
                UserId = x.UserId,
            }).ToList();
        }
        public Movie AddUserMovie(Movie movie)
        {
            var domainMovie = new DomainModels.Movie()
            {
                Name = movie.Name,
                Genre = movie.Genre,
                UserId = movie.UserId,                
            };
            var dbMovie = _repositoryManager.Movies.AddUserMovie(domainMovie);
            _repositoryManager.Save();

            return dbMovie.ToDTO();
        }

        public List<Movie> GetUserMovies(User user)
        {
            var domainUser = new DomainModels.User()
            {
                Email = user.Email,
                Name = user.Name,
                UserId=user.UserId,
            };
            return _repositoryManager.Movies.GetUserMovies(domainUser).Select(x => new Movie()
            {
                Name = x.Name,
                Genre = x.Genre,
                Id = x.Id,
                UserId=x.UserId,
            }).ToList();
        }
    }
}
