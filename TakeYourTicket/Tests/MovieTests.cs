using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Infrastructure.EF.Repositories;

namespace Tests
{
    [TestClass]
    public class MovieTests
    {
        private Movie _movieMock = new Movie("Carros", 128, "Relâmpago McQueen");
        private Movie _movieMock2 = new Movie("Carros 2", 116, "Relâmpago McQueen corre no circuito europeu");
        private Movie _emptyTitleMock = new Movie("", 116, "Relâmpago McQueen corre no circuito europeu");
        private Movie _emptyDurationMock = new Movie("Carros 3", 0, "Relâmpago McQueen corre no circuito europeu");
        private Movie _emptySynopsisMock = new Movie("Carros 3", 116, "");

        private IMovieRepository _movieRepository = new EFMovieRepository();

        [TestMethod]
        public async Task TestMethodCreateMovie()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);

            Assert.IsNotNull(createdMovie);
            Assert.AreEqual("Carros", createdMovie.Title);
            Assert.AreEqual(128, createdMovie.Duration);
            Assert.AreEqual("Relâmpago McQueen", createdMovie.Synopsis);
        }

        public async Task TestMethodUpdateMovie()
        {
            await _movieRepository.Create(_movieMock);
            Movie updatedMovie = await _movieRepository.Update(_movieMock2);

            Assert.IsNotNull(updatedMovie);
            Assert.AreNotEqual(_movieMock, updatedMovie);
        }

        [TestMethod]
        public async Task TestMethodTitleMustBeUnique()
        {
            Movie createdMovie = await _movieRepository.Create(_movieMock);

            Assert.ThrowsException<System.ArgumentException>(async () => await _movieRepository.Create(_movieMock));
        }

        [TestMethod]
        public void TestMethodEmptyTitle()
        {
            Assert.ThrowsException<System.ArgumentNullException>(async () => await _movieRepository.Create(_emptyTitleMock));
        }

        [TestMethod]
        public void TestMethodDurationEqualsZero()
        {
            Assert.ThrowsException<System.ArgumentException>(async () => await _movieRepository.Create(_emptyDurationMock));
        }

        [TestMethod]
        public void TestMethodEmptySynopsis()
        {
            Assert.ThrowsException<System.ArgumentNullException>(async () => await _movieRepository.Create(_emptySynopsisMock));
        }

        [TestCleanup]
        public void CleanUp()
        {
            // implementar a limpeza da tabela do banco
        }
    }
}
