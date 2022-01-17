using Microsoft.EntityFrameworkCore;
using TakeYourTicket.Infrastructure.EF.Types;
using TakeYourTicket.Models;

namespace TakeYourTicket.Infrastructure.EF
{
    public class DataContext : DbContext
    {
        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=TakeYourTicket;User Id=sa;Password=P@ss@0rd!!!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieType());
            modelBuilder.ApplyConfiguration(new SessionType());
        }

    }
}
