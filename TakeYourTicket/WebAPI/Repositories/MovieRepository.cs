using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public Task Create(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}
