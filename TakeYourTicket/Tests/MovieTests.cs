using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Repositories;

namespace Tests
{
    [TestClass]
    public class MovieTests
    {
        private Movie _movieMock = new Movie("Carros", 128, "Relâmpago McQueen");
        private Movie _movieMock2 = new Movie("Carros 2", 116, "Relâmpago McQueen corre no circuito europeu");

        private IMovieRepository _movieRepository = new MovieRepository();

        [TestMethod]
        public async Task TestMethodCreateMovie()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);

            Assert.IsNotNull(createdMovie);
            Assert.AreEqual("Carros", createdMovie.Title);
            Assert.AreEqual(128, createdMovie.Duration);
            Assert.AreEqual("Relâmpago McQueen", createdMovie.Synopsis);
        }

        [TestMethod]
        public async Task TestMethodTitleMustBeUnique()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);
            Movie createdMovie2 = await _movieRepository.Create(_movieMock);

            Assert.IsInstanceOfType("", System.Exception);

            Assert.IsNotNull(createdMovie);
            Assert.AreEqual("Carros", createdMovie.Title);
            Assert.AreEqual(128, createdMovie.Duration);
            Assert.AreEqual("Relâmpago McQueen", createdMovie.Synopsis);
        }
    }
}
