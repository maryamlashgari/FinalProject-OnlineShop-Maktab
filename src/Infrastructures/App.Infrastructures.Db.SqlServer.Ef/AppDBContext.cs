using System;
using System.Collections.Generic;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Db.SqlServer.Ef;

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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Initial Catalog=FinalProject_BaSallam; Integrated Security=true; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.ToTable("Auction");

            entity.HasIndex(e => e.ProductId, "IX_Auction_ProductId");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.DateTimeFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTimeTo).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auction_Product");
        });

        modelBuilder.Entity<Booth>(entity =>
        {
            entity.ToTable("Booth");

            entity.HasIndex(e => e.MedalId, "IX_Booth_MedalId");

            entity.Property(e => e.CathIdsCsv)
                .HasMaxLength(100)
                .HasColumnName("CathIdsCSV");
            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Medal).WithMany(p => p.Booths)
                .HasForeignKey(d => d.MedalId)
                .HasConstraintName("FK_Booth_Medal");
        });

        modelBuilder.Entity<Chategory>(entity =>
        {
            entity.ToTable("Chategory");

            entity.HasIndex(e => e.ParentId, "IX_Chategory_ParentId");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Chategory_Chategory");
        });

        modelBuilder.Entity<Factor>(entity =>
        {
            entity.ToTable("Factor");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<FactorFinalDetail>(entity =>
        {
            entity.ToTable("FactorFinalDetail");

            entity.HasIndex(e => e.FactorId, "IX_FactorFinalDetail_FactorId");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Factor).WithMany(p => p.FactorFinalDetails)
                .HasForeignKey(d => d.FactorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactorFinalDetail_Factor");
        });

        modelBuilder.Entity<Medal>(entity =>
        {
            entity.ToTable("Medal");

            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.ToTable("Offer");

            entity.HasIndex(e => e.AuctionId, "IX_Offer_AuctionId");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.SuggestionDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Auction).WithMany(p => p.Offers)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offer_Auction");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.BoothId, "IX_Product_BoothId");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.ImageAddress).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Booth).WithMany(p => p.Products)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Booth");
        });

        modelBuilder.Entity<ProductFactor>(entity =>
        {
            entity.ToTable("Product_Factor");

            entity.HasIndex(e => e.FactorId, "IX_Product_Factor_FactorId");

            entity.HasIndex(e => e.ProductId, "IX_Product_Factor_ProductId");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Factor).WithMany(p => p.ProductFactors)
                .HasForeignKey(d => d.FactorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Factor_Factor");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductFactors)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Factor_Product");
        });

        modelBuilder.Entity<UserComment>(entity =>
        {
            entity.ToTable("UserComment");

            entity.HasIndex(e => e.ProductId, "IX_UserComment_ProductId");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.UserComments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserComment_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
