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
    public class FactorFinalDetailConfig : IEntityTypeConfiguration<FactorFinalDetail>
    {
        public void Configure(EntityTypeBuilder<FactorFinalDetail> builder)
        {
            builder.ToTable("FactorFinalDetail");

            builder.HasIndex(e => e.FactorId, "IX_FactorFinalDetail_FactorId");

            builder.Property(e => e.CreatedDateTime).HasColumnType("datetime");

            builder.HasOne(d => d.Factor).WithMany(p => p.FactorFinalDetails)
                .HasForeignKey(d => d.FactorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactorFinalDetail_Factor");
        }
    }
}
