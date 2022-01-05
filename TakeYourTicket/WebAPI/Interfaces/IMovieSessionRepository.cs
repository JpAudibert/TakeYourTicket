using System;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IMovieSessionRepository
    {
        public Task<MovieSession> Create(MovieSession movieSession);
        public Task<MovieSession> Update(MovieSession movieSession);
        public MovieSession FindByMovieNameAndDay(string movieName, DateTime? date);
        public void Commit();
    }
}
