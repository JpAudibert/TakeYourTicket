using System;

namespace TakeYourTicket.Models
{
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid SessionId { get; set; }

        public Sale()
        { }

        public Sale(Guid movieId, Guid sessionId)
        {
            Id = Guid.NewGuid();
            MovieId = movieId;
            SessionId = sessionId;
        }
    }
}
