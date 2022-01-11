using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.EF.Types;
using WebAPI.Models;

namespace WebAPI.Infrastructure.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieType());
        }

    }
}
