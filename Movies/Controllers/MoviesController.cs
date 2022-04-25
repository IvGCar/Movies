using BusinessLogic.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Movies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _moviesService;

        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        [ActionName ("Get All Movies")]
        public List<Movie> Get()
        {
            return _moviesService.GetMovies();
        }

        [HttpPost]
        [ActionName("Add User Movie")]
        public Movie Post([FromBody] Movie movie)
        {
            return _moviesService.AddUserMovie(movie);
        }

        [HttpPost]
        [ActionName("Get User Movies")]
        public List<Movie> Post([FromBody] User user)
        {
            return _moviesService.GetUserMovies(user);
        }
    }
}
