using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TakeYourTicket.Models;

namespace TakeYourTicket.Infrastructure.EF.Types
{
    public class MovieType : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(movie => movie.Id);

            builder.Property(movie => movie.Title).HasColumnType("varchar(50)");
            builder.Property(movie => movie.Duration);
            builder.Property(movie => movie.Synopsis).HasColumnType("varchar(150)");
            builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
            builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("getdate()");
        }
    }
}
