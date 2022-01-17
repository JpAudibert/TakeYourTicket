using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeYourTicket.Models;

namespace TakeYourTicket.Infrastructure.EF.Types
{
    public class SaleType : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");
            builder.HasKey(sale => sale.Id);

            builder.Property(sale => sale.Quantity);
            builder
                .HasOne<Session>(sale => sale.Session)
                .WithMany(session => session.Sales)
                .HasForeignKey(sale => sale.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
            builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("getdate()");
        }
    }
}
