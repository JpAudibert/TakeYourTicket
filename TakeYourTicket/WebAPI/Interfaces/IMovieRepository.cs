using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IMovieRepository
    {
        public Task<Movie> Create(Movie movie);
        public Task<Movie> Update(Movie movie);
        public Task Commit();
    }
}
