using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakeYourTicket.Models;

namespace TakeYourTicket.Interfaces
{
    public interface ISessionRepository
    {
        public Task<Session> Create(Session session);
        public Task<Session> Update(Session session, Guid sessionId);
        public Task<Session> FindById(Guid id);
        public IEnumerable<Session> FindByMovieIdAndDay(Guid movieId, DateTime? date);
        public Task Commit();
    }
}
