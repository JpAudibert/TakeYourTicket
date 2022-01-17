using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeYourTicket.Infrastructure.EF;
using TakeYourTicket.Infrastructure.EF.Repositories;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Models;

namespace TakeYourTicket.Tests
{
    [TestClass]
    public class SessionTests
    {
        private DataContext _dataContext;
        private IMovieRepository _movieRepository;
        private ISessionRepository _sessionRepository;

        private Movie _movieMock;
        private Session _sessionMock;
        private Session _sessionMock2;
        private Session _sessionMockWithoutSeats;
        private Session _sessionMockWithNegativePrice;

        [TestInitialize]
        public void Initialize()
        {
            _dataContext = new DataContext();
            _movieRepository = new MovieRepository(_dataContext);
            _sessionRepository = new SessionRepository(_dataContext, _movieRepository);

            _movieMock = new Movie("Carros", 128, "Relâmpago McQueen");
            _sessionMock = new Session(DateTime.UtcNow, 50, 20.00, Guid.Empty);
            _sessionMock2 = new Session(DateTime.UtcNow, 100, 35.00, Guid.Empty);
            _sessionMockWithoutSeats = new Session(DateTime.UtcNow, 0, 35.00, Guid.Empty);
            _sessionMockWithNegativePrice = new Session(DateTime.UtcNow, 50, -1, Guid.Empty);
        }

        [TestMethod]
        public async Task CreateSession()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);
            _sessionMock.MovieId = createdMovie.Id;

            Session createdSession = await _sessionRepository.Create(_sessionMock);

            Assert.IsNotNull(createdSession);
            Assert.AreEqual(createdSession.NumberOfSeats, 50);
            Assert.AreEqual(createdSession.Price, 20.00);
            Assert.AreEqual(createdSession.MovieId, createdMovie.Id);
        }

        [TestMethod]
        public async Task UpdateSession()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);
            _sessionMock.MovieId = createdMovie.Id;

            Session createdSession = await _sessionRepository.Create(_sessionMock);
            Session updatedSession = await _sessionRepository.Update(_sessionMock2, createdSession.Id);

            Assert.IsNotNull(updatedSession);
            Assert.AreNotEqual(_sessionMock, updatedSession);
        }

        [TestMethod]
        public async Task FindByMovieIdAndDate()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);
            _sessionMock.MovieId = createdMovie.Id;

            Session createdSession = await _sessionRepository.Create(_sessionMock);
            IEnumerable<Session> sessions = _sessionRepository.FindByMovieIdAndDay(createdSession.MovieId, createdSession.ExhibitionDate);

            Assert.IsNotNull(sessions);
            Assert.AreEqual(createdSession, sessions.First());
        }

        [TestMethod]
        public void SessionWithoutSeats()
        {
            _sessionMockWithoutSeats.MovieId = _movieMock.Id;
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await _sessionRepository.Create(_sessionMockWithoutSeats), "Number of seats cannot be equal or less than 0.");
        }

        [TestMethod]
        public void SessionWithoutPrice()
        {
            _sessionMockWithNegativePrice.MovieId = _movieMock.Id;
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await _sessionRepository.Create(_sessionMockWithNegativePrice), "Price must be at least 0.");
        }

        [TestMethod]
        public void SessionWithoutMovie()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _sessionRepository.Create(_sessionMock), "Film reference is empty.");
        }

        [TestCleanup]
        public void CleanUp()
        {
            _dataContext.Sessions.RemoveRange(_dataContext.Sessions);
            _dataContext.SaveChanges();
        }
    }
}
