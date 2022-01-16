using System;
using System.Threading.Tasks;
using TakeYourTicket.Infrastructure.EF;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Models;

namespace TakeYourTicket.Infrastructure.EF.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _dataContext;

        public MovieRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Movie> Create(Movie movie)
        {
            if (!ValidateMovie(movie))
            {
                return null;
            }

            Movie newMovie = new Movie(movie);

            _dataContext.Movies.Add(newMovie);

            await Commit();

            return newMovie;
        }

        public async Task<Movie> Update(Movie movie, Guid movieId)
        {
            Movie foundMovie = await _dataContext.Movies.FindAsync(movieId);

            if (foundMovie == null)
            {
                return null;
            }

            if(movie.Title != null)
            {
                foundMovie.Title = movie.Title;
            }

            if (movie.Duration > 0)
            {
                foundMovie.Duration = movie.Duration;
            }

            if (movie.Synopsis != null)
            {
                foundMovie.Synopsis = movie.Synopsis;
            }

            _dataContext.Movies.Update(foundMovie);

            await Commit();

            return foundMovie;
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
        }

        private Boolean ValidateMovie(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.Title))
            {
                throw new ArgumentNullException("Title cannot be null or empty.");
            }

            if (movie.Duration <= 0)
            {
                throw new ArgumentException("Duration cannot be equal or less than 0.");
            }

            if (string.IsNullOrEmpty(movie.Synopsis))
            {
                throw new ArgumentNullException("Synopsis cannot be null or empty.");
            }

            return true;
        }
    }
}
