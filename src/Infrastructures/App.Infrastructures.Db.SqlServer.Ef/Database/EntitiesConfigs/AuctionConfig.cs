using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Db.SqlServer.Ef.Database.EntitiesConfigs
{
    public class AuctionConfig : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.ToTable("Auction");

            builder.HasIndex(e => e.ProductId, "IX_Auction_ProductId");

            builder.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            builder.Property(e => e.DateTimeFrom).HasColumnType("datetime");
            builder.Property(e => e.DateTimeTo).HasColumnType("datetime");

            builder.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auction_Product");
        }
    }
}
