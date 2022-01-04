using System;

namespace WebAPI.Models
{
    public sealed class MovieSession
    {
        public Guid Id { get; }
        public DateTime ExhibitionDate { get; set; }
        public int NumberOfSeats { get; set; }
        public double Price { get; set; }
        public Movie Movie { get; set; }

        public MovieSession(MovieSession movieSession)
        {
            Id = Guid.NewGuid();
            ExhibitionDate = movieSession.ExhibitionDate;
            NumberOfSeats = movieSession.NumberOfSeats;
            Price = movieSession.Price;
            Movie = movieSession.Movie;
        }
    }
}
