using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editBannerTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTitleEn",
                table: "BannerTbls");

            migrationBuilder.DropColumn(
                name: "SummaryEn",
                table: "BannerTbls");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "BannerTbls");

            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "BannerTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbb17e37-b92d-4e1e-b1e0-aa905e936f4a", "AQAAAAIAAYagAAAAEAu5S0Deu5ec5QM35XHHchFNTSAkUexOjpIV/OedpXY5I9tAd5e1pgF4O+qeFKKa6Q==", "42fcb791-d9d8-47a6-b9c6-a40f985c67e3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortId",
                table: "BannerTbls");

            migrationBuilder.AddColumn<string>(
                name: "SubTitleEn",
                table: "BannerTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SummaryEn",
                table: "BannerTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "BannerTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30ddd5dd-3c82-49e4-8b5f-453122b0c3e8", "AQAAAAIAAYagAAAAEDl8frNl/A4Kzjsg/beJCLZh7FGh/d9AeufDXvB6hxZBwM7p7I+hNrQmNkhDV9vQ1A==", "43d8b0f6-d4c4-4064-b1fc-faf38b63c593" });
        }
    }
}
