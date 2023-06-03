using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Db.SqlServer.Ef.Database.EntitiesConfigs
{
    public class OfferConfig : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offer");

            builder.HasIndex(e => e.AuctionId, "IX_Offer_AuctionId");

            builder.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            builder.Property(e => e.SuggestionDateTime).HasColumnType("datetime");

            builder.HasOne(d => d.Auction).WithMany(p => p.Offers)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offer_Auction");
        }
    }
}
