using System;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IMovieSessionRepository
    {
        public Task<Session> Create(Session movieSession);
        public Task<Session> Update(Session movieSession);
        public Session FindByMovieNameAndDay(string movieName, DateTime? date);
        public void Commit();
    }
}
