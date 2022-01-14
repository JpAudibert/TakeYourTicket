using System;
using System.Collections.Generic;

namespace TakeYourTicket.Models
{
    public sealed class Movie
    {
        public Guid Id { get; }
        public string Title { get; }
        public int Duration { get; }
        public string Synopsis { get; }

        public IEnumerable<Session> Sessions;

        public Movie() { }

        public Movie(Movie movie)
        {
            Id = Guid.NewGuid();
            Title = movie.Title;
            Duration = movie.Duration;
            Synopsis = movie.Synopsis;
        }

        public Movie(string title, int duration, string synopsis)
        {
            Id = Guid.NewGuid();
            Title = title;
            Duration = duration;
            Synopsis = synopsis;
        }
    }
}
