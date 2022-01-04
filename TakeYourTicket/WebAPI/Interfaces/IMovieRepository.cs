using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IMovieRepository
    {
        public void Create(Movie movie);
        public void Update(Movie movie);
        public void Commit();
    }
}
