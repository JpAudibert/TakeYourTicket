using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Models;

namespace TakeYourTicket.Infrastructure.EF.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMovieRepository _movieRepository;

        public SessionRepository(DataContext dataContext, IMovieRepository movieRepository)
        {
            _dataContext = dataContext;
            _movieRepository = movieRepository;
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Session> Create(Session session)
        {
            if (session.Price < 0)
            {
                throw new ArgumentException("Price must be at least 0.");
            }

            if (session.NumberOfSeats <= 0)
            {
                throw new ArgumentException("Number of seats cannot be equal or less than 0.");
            }

            if (session.MovieId == Guid.Empty)
            {
                throw new ArgumentNullException("Film reference is empty.");
            }

            Session newSession = new Session(session);

            _dataContext.Sessions.Add(newSession);

            await Commit();

            return newSession;
        }

        public async Task<Session> FindById(Guid id)
        {
            return await _dataContext.Sessions.FindAsync(id);
        }

        public IEnumerable<Session> FindByMovieIdAndDay(Guid movieId, DateTime? date)
        {
            if (date == null)
            {
                return _dataContext.Sessions.Where(session => session.MovieId == movieId);
            }

            return _dataContext.Sessions.Where(session => session.MovieId == movieId && session.ExhibitionDate == date);
        }

        public async Task<Session> Update(Session session, Guid sessionId)
        {
            Session foundSession = await FindById(sessionId);
            Movie foundMovie = await _movieRepository.FindById(session.MovieId);

            if (foundSession == null)
            {
                return null;
            }

            if (session.NumberOfSeats > 0)
            {
                foundSession.NumberOfSeats = session.NumberOfSeats;
            }

            if (session.Price >= 0)
            {
                foundSession.Price = session.Price;
            }

            if (session.ExhibitionDate != session.ExhibitionDate)
            {
                foundSession.ExhibitionDate = session.ExhibitionDate;
            }

            if (foundMovie != null)
            {
                foundSession.MovieId = session.MovieId;
            }

            _dataContext.Sessions.Update(foundSession);

            await Commit();

            return foundSession;
        }
    }
}
