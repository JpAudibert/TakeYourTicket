using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TakeYourTicket.Models;

namespace TakeYourTicket.Infrastructure.EF.Types
{
    public class SessionType : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Session");
            builder.HasKey(session => session.Id);

            builder.Property(session => session.ExhibitionDate);
            builder.Property(session => session.NumberOfSeats);
            builder.Property(session => session.Price).HasColumnType("decimal(10,2)");

            builder
                .HasOne<Movie>(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
            builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("getdate()");
        }
    }
}
