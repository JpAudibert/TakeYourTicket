using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TakeYourTicket.Infrastructure.EF.InputModels;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Models;

namespace WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovieRepository movieRepository, ILogger<MovieController> logger)
        {
            _movieRepository = movieRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieInputModel newMovieInputModel)
        {
            if (newMovieInputModel == null)
            {
                return BadRequest();
            }

            Movie newMovie = new Movie(newMovieInputModel.Title, newMovieInputModel.Duration, newMovieInputModel.Synopsis);
            _logger.LogInformation("Movie {movieName} created in memory", newMovie.Title);

            Movie createdMovie = await _movieRepository.Create(newMovie);
            _logger.LogInformation("Movie {movieTitle}, with Id {movieId}, created in the database", createdMovie.Title, createdMovie.Id);

            return Ok(createdMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateMovieInputModel updateMovie)
        {
            if (!Guid.TryParse(id, out var movieId))
            {
                return BadRequest("Invalid Id");
            }

            if (updateMovie == null)
            {
                return BadRequest();
            }

            Movie toUpdateMovie = new Movie(updateMovie.Title, updateMovie.Duration, updateMovie.Synopsis);
            _logger.LogInformation("Movie {movieName} created in memory", toUpdateMovie.Title);

            Movie updatedMovie = await _movieRepository.Update(toUpdateMovie, movieId);
            _logger.LogInformation("Movie {movieTitle}, with Id {movieId}, updated in the database", updatedMovie.Title, updatedMovie.Id);

            return Ok(updatedMovie);
        }
    }
}
