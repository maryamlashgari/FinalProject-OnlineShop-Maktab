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
    public class ChategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Chategory");

            builder.HasIndex(e => e.ParentId, "IX_Chategory_ParentId");

            builder.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Name).HasMaxLength(250);

            builder.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Chategory_Chategory");
        }
    }
}
