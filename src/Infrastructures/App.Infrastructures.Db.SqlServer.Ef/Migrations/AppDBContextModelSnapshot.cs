﻿// <auto-generated />
using System;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infrastructures.Db.SqlServer.Ef.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Core.Entities.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("BestPriceOffer")
                        .HasColumnType("float");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateTimeFrom")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateTimeTo")
                        .HasColumnType("datetime");

                    b.Property<bool?>("FinishedFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProductId" }, "IX_Auction_ProductId");

                    b.ToTable("Auction", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Booth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CathIdsCsv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CathIdsCSV");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("MedalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MedalId" }, "IX_Booth_MedalId");

                    b.ToTable("Booth", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Chategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ParentId" }, "IX_Chategory_ParentId");

                    b.ToTable("Chategory", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Factor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Factor", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.FactorFinalDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoothId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("FactorId")
                        .HasColumnType("int");

                    b.Property<double>("GeneralPrice")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FactorId" }, "IX_FactorFinalDetail_FactorId");

                    b.ToTable("FactorFinalDetail", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Medal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Commission")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<double?>("SalesAmount")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Medal", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSuccessFlag")
                        .HasColumnType("bit");

                    b.Property<double>("SuggestedPrice")
                        .HasColumnType("float");

                    b.Property<DateTime?>("SuggestionDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AuctionId" }, "IX_Offer_AuctionId");

                    b.ToTable("Offer", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoothId")
                        .HasColumnType("int");

                    b.Property<bool?>("ConfirmedByAdmin")
                        .HasColumnType("bit");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SellType")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BoothId" }, "IX_Product_BoothId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.ProductFactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("FactorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FactorId" }, "IX_Product_Factor_FactorId");

                    b.HasIndex(new[] { "ProductId" }, "IX_Product_Factor_ProductId");

                    b.ToTable("Product_Factor", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.UserComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ConfirmedByAdmin")
                        .HasColumnType("bit");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeletedFlag")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProductId" }, "IX_UserComment_ProductId");

                    b.ToTable("UserComment", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Auction", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Product", "Product")
                        .WithMany("Auctions")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Auction_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Booth", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Medal", "Medal")
                        .WithMany("Booths")
                        .HasForeignKey("MedalId")
                        .HasConstraintName("FK_Booth_Medal");

                    b.Navigation("Medal");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Chategory", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Chategory", "Parent")
                        .WithMany("InverseParent")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_Chategory_Chategory");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.FactorFinalDetail", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Factor", "Factor")
                        .WithMany("FactorFinalDetails")
                        .HasForeignKey("FactorId")
                        .IsRequired()
                        .HasConstraintName("FK_FactorFinalDetail_Factor");

                    b.Navigation("Factor");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Offer", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Auction", "Auction")
                        .WithMany("Offers")
                        .HasForeignKey("AuctionId")
                        .IsRequired()
                        .HasConstraintName("FK_Offer_Auction");

                    b.Navigation("Auction");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Product", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Booth", "Booth")
                        .WithMany("Products")
                        .HasForeignKey("BoothId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Booth");

                    b.Navigation("Booth");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.ProductFactor", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Factor", "Factor")
                        .WithMany("ProductFactors")
                        .HasForeignKey("FactorId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Factor_Factor");

                    b.HasOne("App.Domain.Core.Entities.Product", "Product")
                        .WithMany("ProductFactors")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Factor_Product");

                    b.Navigation("Factor");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.UserComment", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Product", "Product")
                        .WithMany("UserComments")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_UserComment_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Auction", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Booth", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Chategory", b =>
                {
                    b.Navigation("InverseParent");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Factor", b =>
                {
                    b.Navigation("FactorFinalDetails");

                    b.Navigation("ProductFactors");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Medal", b =>
                {
                    b.Navigation("Booths");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Product", b =>
                {
                    b.Navigation("Auctions");

                    b.Navigation("ProductFactors");

                    b.Navigation("UserComments");
                });
#pragma warning restore 612, 618
        }
    }
}
