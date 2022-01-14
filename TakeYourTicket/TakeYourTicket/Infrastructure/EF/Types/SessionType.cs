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
            builder.Property<DateTime>("CreatedAt");
            builder.Property<DateTime>("UpdatedAt");
        }
    }
}
