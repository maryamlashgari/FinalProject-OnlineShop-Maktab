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
    public class UserCommentConfig : IEntityTypeConfiguration<UserComment>
    {
        public void Configure(EntityTypeBuilder<UserComment> builder)
        {
            builder.ToTable("UserComment");

            builder.HasIndex(e => e.ProductId, "IX_UserComment_ProductId");

            builder.Property(e => e.CreatedDateTime).HasColumnType("datetime");

            builder.HasOne(d => d.Product).WithMany(p => p.UserComments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserComment_Product");
        }
    }
}
