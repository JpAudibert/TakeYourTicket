using System;
using System.Threading.Tasks;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Models;

namespace WebAPI.Infrastructure.EF.Repositories
{
    public class EFMovieRepository : IMovieRepository
    {
        //private readonly CinemaContext _dbContext;

        public async Task<Movie> Create(Movie movie)
        {
            try
            {
                if (string.IsNullOrEmpty(movie.Title))
                {
                    throw new ArgumentNullException("Title cannot be null or empty.");
                }

                if (movie.Duration == 0)
                {
                    throw new ArgumentException("Duration cannot be equal to 0.");
                }

                if (string.IsNullOrEmpty(movie.Synopsis))
                {
                    throw new ArgumentNullException("Synopsis cannot be null or empty.");
                }

                Movie newMovie = new Movie(movie);

                await Commit();

                return newMovie;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Movie> Update(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public async Task Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}
