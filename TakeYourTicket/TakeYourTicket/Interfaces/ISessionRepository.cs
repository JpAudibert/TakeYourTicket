using System;
using System.Threading.Tasks;
using TakeYourTicket.Models;

namespace TakeYourTicket.Interfaces
{
    public interface ISessionRepository
    {
        public Task<Session> Create(Session session);
        public Task<Session> Update(Session session);
        public Session FindByMovieNameAndDay(Guid movieId, DateTime? date);
        public void Commit();
    }
}
