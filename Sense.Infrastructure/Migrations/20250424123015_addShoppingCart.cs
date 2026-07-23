using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BannerTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowText = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerTbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItemTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductAmount = table.Column<double>(type: "float", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductOfferDisVal = table.Column<double>(type: "float", nullable: true),
                    ProductNetPrice = table.Column<double>(type: "float", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItemTbls_ShoppingCartTbls_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCartTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30ddd5dd-3c82-49e4-8b5f-453122b0c3e8", "AQAAAAIAAYagAAAAEDl8frNl/A4Kzjsg/beJCLZh7FGh/d9AeufDXvB6hxZBwM7p7I+hNrQmNkhDV9vQ1A==", "43d8b0f6-d4c4-4064-b1fc-faf38b63c593" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItemTbls_ShoppingCartId",
                table: "CartItemTbls",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTbls_CustomerId",
                table: "ShoppingCartTbls",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerTbls");

            migrationBuilder.DropTable(
                name: "CartItemTbls");

            migrationBuilder.DropTable(
                name: "ShoppingCartTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9d18ce7-5ea3-4fdf-8f17-80e427927d3c", "AQAAAAIAAYagAAAAECYDFZUBM1s6nv3W7Zh6uF1uUjtyhtrirIGXLMV95y8SEXq4/r+9IpkANqLK+A3HNg==", "f80f88d5-ac4a-42f8-9cbd-33352da0cd9b" });
        }
    }
}
