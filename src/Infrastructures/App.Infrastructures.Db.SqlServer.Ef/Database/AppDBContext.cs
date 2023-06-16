using System;
using System.Collections.Generic;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database.EntitiesConfigs;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Db.SqlServer.Ef.Database;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Booth> Booths { get; set; }

    public virtual DbSet<Chategory> Chategories { get; set; }

    public virtual DbSet<Factor> Factors { get; set; }

    public virtual DbSet<FactorFinalDetail> FactorFinalDetails { get; set; }

    public virtual DbSet<Medal> Medals { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductFactor> ProductFactors { get; set; }

    public virtual DbSet<UserComment> UserComments { get; set; }

    /// <summary>
    /// todo : After Inmplementing DI in this Project.should move connectionString
    /// </summary>
    /// <param name="optionsBuilder"></param>
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=.; Initial Catalog=FinalProject_BaSallam; Integrated Security=true; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuctionConfig());
        modelBuilder.ApplyConfiguration(new BoothConfig());
        modelBuilder.ApplyConfiguration(new ChategoryConfig());
        modelBuilder.ApplyConfiguration(new FactorConfig());
        modelBuilder.ApplyConfiguration(new FactorFinalDetailConfig());
        modelBuilder.ApplyConfiguration(new MedalConfig());
        modelBuilder.ApplyConfiguration(new OfferConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new ProductFactorConfig());
        modelBuilder.ApplyConfiguration(new UserCommentConfig());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
