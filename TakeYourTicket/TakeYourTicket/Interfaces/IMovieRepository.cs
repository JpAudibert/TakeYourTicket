using System;
using System.Threading.Tasks;
using TakeYourTicket.Models;

namespace TakeYourTicket.Interfaces
{
    public interface IMovieRepository
    {
        public Task<Movie> FindById(Guid id);
        public Task<Movie> Create(Movie movie);
        public Task<Movie> Update(Movie movie, Guid id);
        public Task Commit();
    }
}
