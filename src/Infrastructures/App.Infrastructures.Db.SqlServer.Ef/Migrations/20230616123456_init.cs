using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructures.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chategory_Chategory",
                        column: x => x.ParentId,
                        principalTable: "Chategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Factor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Commission = table.Column<double>(type: "float", nullable: true),
                    SalesAmount = table.Column<double>(type: "float", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactorFinalDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorId = table.Column<int>(type: "int", nullable: false),
                    GeneralPrice = table.Column<double>(type: "float", nullable: false),
                    BoothId = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactorFinalDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactorFinalDetail_Factor",
                        column: x => x.FactorId,
                        principalTable: "Factor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Booth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CathIdsCSV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MedalId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booth_Medal",
                        column: x => x.MedalId,
                        principalTable: "Medal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SellType = table.Column<int>(type: "int", nullable: false),
                    BoothId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ImageAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ConfirmedByAdmin = table.Column<bool>(type: "bit", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Booth",
                        column: x => x.BoothId,
                        principalTable: "Booth",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DateTimeFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateTimeTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    BestPriceOffer = table.Column<double>(type: "float", nullable: true),
                    FinishedFlag = table.Column<bool>(type: "bit", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auction_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_Factor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FactorId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Factor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Factor_Factor",
                        column: x => x.FactorId,
                        principalTable: "Factor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Factor_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ConfirmedByAdmin = table.Column<bool>(type: "bit", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComment_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SuggestedPrice = table.Column<double>(type: "float", nullable: false),
                    SuggestionDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsSuccessFlag = table.Column<bool>(type: "bit", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeletedFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Auction",
                        column: x => x.AuctionId,
                        principalTable: "Auction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auction_ProductId",
                table: "Auction",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Booth_MedalId",
                table: "Booth",
                column: "MedalId");

            migrationBuilder.CreateIndex(
                name: "IX_Chategory_ParentId",
                table: "Chategory",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FactorFinalDetail_FactorId",
                table: "FactorFinalDetail",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_AuctionId",
                table: "Offer",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BoothId",
                table: "Product",
                column: "BoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Factor_FactorId",
                table: "Product_Factor",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Factor_ProductId",
                table: "Product_Factor",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComment_ProductId",
                table: "UserComment",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chategory");

            migrationBuilder.DropTable(
                name: "FactorFinalDetail");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Product_Factor");

            migrationBuilder.DropTable(
                name: "UserComment");

            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "Factor");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Booth");

            migrationBuilder.DropTable(
                name: "Medal");
        }
    }
}
