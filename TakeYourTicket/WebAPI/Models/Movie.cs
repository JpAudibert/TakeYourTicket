using System;

namespace WebAPI.Models
{
    public sealed class Movie
    {
        public Guid Id { get; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Synopsis { get; set; }

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
