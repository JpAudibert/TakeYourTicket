using System;
using System.Collections.Generic;

namespace TakeYourTicket.Models
{
    public sealed class Session
    {
        public Guid Id { get; }
        public DateTime ExhibitionDate { get; set; }
        public int NumberOfSeats { get; set; }
        public double Price { get; set; }
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }
        public IEnumerable<Sale> Sales { get; set; }

        public Session()
        { }

        public Session(Session session)
        {
            Id = Guid.NewGuid();
            ExhibitionDate = session.ExhibitionDate;
            NumberOfSeats = session.NumberOfSeats;
            Price = session.Price;
            MovieId = session.MovieId;
        }

        public Session(DateTime exhibitionDate, int numberOfSeats, double price, Guid movieId)
        {
            Id = Guid.NewGuid();
            ExhibitionDate = exhibitionDate;
            NumberOfSeats = numberOfSeats;
            Price = price;
            MovieId = movieId;
        }
    }
}
