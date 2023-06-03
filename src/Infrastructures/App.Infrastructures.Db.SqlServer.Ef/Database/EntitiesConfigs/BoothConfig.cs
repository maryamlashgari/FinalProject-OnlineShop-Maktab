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
    public class BoothConfig : IEntityTypeConfiguration<Booth>
    {
        public void Configure(EntityTypeBuilder<Booth> builder)
        {
            builder.ToTable("Booth");

            builder.HasIndex(e => e.MedalId, "IX_Booth_MedalId");

            builder.Property(e => e.CathIdsCsv)
                .HasMaxLength(100)
                .HasColumnName("CathIdsCSV");
            builder.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            builder.Property(e => e.Name).HasMaxLength(250);

            builder.HasOne(d => d.Medal).WithMany(p => p.Booths)
                .HasForeignKey(d => d.MedalId)
                .HasConstraintName("FK_Booth_Medal");
        }
    }
}
