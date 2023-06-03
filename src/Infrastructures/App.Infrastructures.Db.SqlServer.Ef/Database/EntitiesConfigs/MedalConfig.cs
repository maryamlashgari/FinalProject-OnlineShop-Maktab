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
    public class MedalConfig : IEntityTypeConfiguration<Medal>
    {
        public void Configure(EntityTypeBuilder<Medal> builder)
        {
            builder.ToTable("Medal");

            builder.Property(e => e.Title).HasMaxLength(250);
        }
    }
}
