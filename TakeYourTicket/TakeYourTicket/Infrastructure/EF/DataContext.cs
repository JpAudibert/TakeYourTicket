﻿using Microsoft.EntityFrameworkCore;
using TakeYourTicket.Infrastructure.EF.Types;
using TakeYourTicket.Models;

namespace TakeYourTicket.Infrastructure.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> MovieSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieType());
            modelBuilder.ApplyConfiguration(new SessionType());
        }

    }
}