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
    public class ProductFactorConfig : IEntityTypeConfiguration<ProductFactor>
    {
        public void Configure(EntityTypeBuilder<ProductFactor> builder)
        {
            builder.ToTable("Product_Factor");

            builder.HasIndex(e => e.FactorId, "IX_Product_Factor_FactorId");

            builder.HasIndex(e => e.ProductId, "IX_Product_Factor_ProductId");

            builder.Property(e => e.CreatedDateTime).HasColumnType("datetime");

            builder.HasOne(d => d.Factor).WithMany(p => p.ProductFactors)
                .HasForeignKey(d => d.FactorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Factor_Factor");

            builder.HasOne(d => d.Product).WithMany(p => p.ProductFactors)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Factor_Product");
        }
    }
}
