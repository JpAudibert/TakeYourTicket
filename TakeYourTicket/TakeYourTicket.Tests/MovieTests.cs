using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Models;
using TakeYourTicket.Infrastructure.EF.Repositories;
using TakeYourTicket.Infrastructure.EF;
using System;

namespace Tests
{
    [TestClass]
    public class MovieTests
    {
        private Movie _movieMock;
        private Movie _movieMock2;
        private Movie _emptyTitleMock;
        private Movie _emptyDurationMock;
        private Movie _emptySynopsisMock;

        private DataContext _dataContext;
        private IMovieRepository _movieRepository;

        [TestInitialize]
        public void Initialize()
        {
            _dataContext = new DataContext();
            _movieRepository = new MovieRepository(_dataContext);

            _movieMock = new Movie("Carros", 128, "Relâmpago McQueen");
            _movieMock2 = new Movie("Carros 2", 116, "Relâmpago McQueen corre no circuito europeu");

            _emptyTitleMock = new Movie("", 116, "Relâmpago McQueen corre no circuito europeu");
            _emptyDurationMock = new Movie("Carros 3", 0, "Relâmpago McQueen corre no circuito europeu");
            _emptySynopsisMock = new Movie("Carros 3", 116, "");
        }

        [TestMethod]
        public async Task CreateMovie()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);

            Assert.IsNotNull(createdMovie);
            Assert.AreEqual("Carros", createdMovie.Title);
            Assert.AreEqual(128, createdMovie.Duration);
            Assert.AreEqual("Relâmpago McQueen", createdMovie.Synopsis);
        }

        [TestMethod]
        public async Task UpdateMovie()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);

            Movie updatedMovie = await _movieRepository.Update(_movieMock2, createdMovie.Id);

            Assert.IsNotNull(updatedMovie);
            Assert.AreNotEqual(_movieMock, updatedMovie);
        }

        [TestMethod]
        public void EmptyTitle()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _movieRepository.Create(_emptyTitleMock), "Title cannot be null or empty.");
        }

        [TestMethod]
        public void DurationEqualsZero()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(async () => await _movieRepository.Create(_emptyDurationMock), "Duration cannot be equal or less than 0.");
        }

        [TestMethod]
        public void EmptySynopsis()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _movieRepository.Create(_emptySynopsisMock), "Synopsis cannot be null or empty.");
        }

        [TestCleanup]
        public void CleanUp()
        {
            _dataContext.Movies.RemoveRange(_dataContext.Movies);
            _dataContext.SaveChanges();
        }
    }
}
