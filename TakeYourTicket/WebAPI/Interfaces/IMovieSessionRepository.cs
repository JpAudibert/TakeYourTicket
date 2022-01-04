using System;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IMovieSessionRepository
    {
        public void Create(MovieSession movieSession);
        public void Update(MovieSession movieSession);
        public MovieSession FindByMovieNameAndDay(string movieName, DateTime? date);
        public void Commit();
    }
}
