using System;

namespace WebAPI.Models
{
    public sealed class Session
    {
        public Guid Id { get; }
        public DateTime ExhibitionDate { get; set; }
        public int NumberOfSeats { get; set; }
        public double Price { get; set; }

        public Session(Session session)
        {
            Id = Guid.NewGuid();
            ExhibitionDate = session.ExhibitionDate;
            NumberOfSeats = session.NumberOfSeats;
            Price = session.Price;
        }

        public Session(DateTime exhibitionDate, int numberOfSeats, double price)
        {
            Id = Guid.NewGuid();
            ExhibitionDate = exhibitionDate;
            NumberOfSeats = numberOfSeats;
            Price = price;
        }
    }
}
