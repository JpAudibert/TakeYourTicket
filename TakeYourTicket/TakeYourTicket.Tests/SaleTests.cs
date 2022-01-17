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
    public class SaleTests
    {
        private DataContext _dataContext;
        private IMovieRepository _movieRepository;
        private ISessionRepository _sessionRepository;
        private ISaleRepository _saleRepository;

        private Movie _movieMock;
        private Session _sessionMock;
        private Sale _saleMock;
        private Sale _saleMockQuantityNotAllowed;

        [TestInitialize]
        public void Initialize()
        {
            _dataContext = new DataContext();
            _movieRepository = new MovieRepository(_dataContext);
            _sessionRepository = new SessionRepository(_dataContext, _movieRepository);
            _saleRepository = new SaleRepository(_dataContext, _sessionRepository);

            _movieMock = new Movie("Carros", 128, "Relâmpago McQueen");
            _sessionMock = new Session(DateTime.UtcNow, 50, 20.00, Guid.Empty);
            _saleMock = new Sale(5, Guid.Empty);
            _saleMockQuantityNotAllowed = new Sale(51, Guid.Empty);
        }

        [TestMethod]
        public async Task CreateSale()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);
            _sessionMock.MovieId = createdMovie.Id;
            
            Session createdSession = await _sessionRepository.Create(_sessionMock);
            _saleMock.SessionId = createdSession.Id;

            Sale createdSale = await _saleRepository.Create(_saleMock);

            Assert.IsNotNull(createdSale);
            Assert.AreEqual(createdSale.Quantity, 5);
            Assert.AreEqual(createdSale.SessionId, createdSession.Id);
        }

        [TestMethod]
        public async Task SaleOfSoldOutSession()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);
            _sessionMock.MovieId = createdMovie.Id;

            Session createdSession = await _sessionRepository.Create(_sessionMock);
            _saleMockQuantityNotAllowed.SessionId = createdSession.Id;

            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await _saleRepository.Create(_saleMockQuantityNotAllowed), "Quantity is over the limit.");
        }

        [TestCleanup]
        public void CleanUp()
        {
            _dataContext.Movies.RemoveRange(_dataContext.Movies);
            _dataContext.Sessions.RemoveRange(_dataContext.Sessions);
            _dataContext.Sales.RemoveRange(_dataContext.Sales);
            _dataContext.SaveChanges();
        }
    }
}
