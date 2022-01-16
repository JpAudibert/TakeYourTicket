using Microsoft.AspNetCore.Mvc;
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
        private IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNewMovieInputModel newMovieInputModel)
        {
            try
            {
                if (newMovieInputModel == null)
                {
                    return BadRequest();
                }

                Movie newMovie = new Movie(newMovieInputModel.Title, newMovieInputModel.Duration, newMovieInputModel.Synopsis);

                Movie createdMovie = await _movieRepository.Create(newMovie);

                return Ok(createdMovie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateMovieInputModel updateMovie)
        {
            try
            {
                if(!Guid.TryParse(id, out var movieId))
                {
                    return BadRequest("Invalid Id");
                }
                
                if (updateMovie == null)
                {
                    return NotFound();
                }

                Movie toUpdateMovie = new Movie(updateMovie.Title, updateMovie.Duration, updateMovie.Synopsis);

                Movie updatedMovie = await _movieRepository.Update(toUpdateMovie, movieId);

                return Ok(updatedMovie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
