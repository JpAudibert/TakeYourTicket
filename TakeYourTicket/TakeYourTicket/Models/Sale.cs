using System;

namespace TakeYourTicket.Models
{
    public sealed class Sale
    {
        public Guid Id { get; }
        public int Quantity { get; set; }
        public Guid SessionId { get; set; }

        public Session Session { get; set; }

        public Sale()
        { }

        public Sale(int quantity, Guid sessionId)
        {
            Id = Guid.NewGuid();
            Quantity = quantity;
            SessionId = sessionId;
        }

        public Sale(Sale sale)
        {
            Id = Guid.NewGuid();
            Quantity = sale.Quantity;
            SessionId = sale.SessionId;
        }
    }
}
