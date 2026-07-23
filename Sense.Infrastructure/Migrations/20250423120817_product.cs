using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Domain.Migrations
{
    /// <inheritdoc />
    public partial class product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbl_ProductTbl_SparePartId",
                table: "InvoiceTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTbl_CategoryTbls_CategoryId",
                table: "ProductTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTbl",
                table: "ProductTbl");

            migrationBuilder.RenameTable(
                name: "ProductTbl",
                newName: "ProductTbls");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTbl_CategoryId",
                table: "ProductTbls",
                newName: "IX_ProductTbls_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ProductTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTbls",
                table: "ProductTbls",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9d18ce7-5ea3-4fdf-8f17-80e427927d3c", "AQAAAAIAAYagAAAAECYDFZUBM1s6nv3W7Zh6uF1uUjtyhtrirIGXLMV95y8SEXq4/r+9IpkANqLK+A3HNg==", "f80f88d5-ac4a-42f8-9cbd-33352da0cd9b" });

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_SparePartId",
                table: "InvoiceTbl",
                column: "SparePartId",
                principalTable: "ProductTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTbls_CategoryTbls_CategoryId",
                table: "ProductTbls",
                column: "CategoryId",
                principalTable: "CategoryTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_SparePartId",
                table: "InvoiceTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTbls_CategoryTbls_CategoryId",
                table: "ProductTbls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTbls",
                table: "ProductTbls");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ProductTbls");

            migrationBuilder.RenameTable(
                name: "ProductTbls",
                newName: "ProductTbl");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTbls_CategoryId",
                table: "ProductTbl",
                newName: "IX_ProductTbl_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTbl",
                table: "ProductTbl",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a91aa12-01b9-429f-af67-851667a0a7e0", "AQAAAAIAAYagAAAAEHiUi2KKSeJq8yj/RFF1OVFuVuYI2s9mosc7iIn9QzWPQdzGH/ScQ/OSxE1gY0kl4A==", "dca82cdf-8ccb-46ab-8196-6a6a6ca9d4d1" });

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbl_ProductTbl_SparePartId",
                table: "InvoiceTbl",
                column: "SparePartId",
                principalTable: "ProductTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTbl_CategoryTbls_CategoryId",
                table: "ProductTbl",
                column: "CategoryId",
                principalTable: "CategoryTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
