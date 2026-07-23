using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addServiceTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTbls", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20ced901-dfb6-41da-b5dc-5646bc929367", "AQAAAAIAAYagAAAAEMIikX0IwUQ3LJ4cuWe3EkAonbbOpuMn1P9XoZ3HK76P87yj2y5/1WHKVZfTOameJQ==", "20c88521-3b6b-43b0-bd5f-a95e212f43ce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbb17e37-b92d-4e1e-b1e0-aa905e936f4a", "AQAAAAIAAYagAAAAEAu5S0Deu5ec5QM35XHHchFNTSAkUexOjpIV/OedpXY5I9tAd5e1pgF4O+qeFKKa6Q==", "42fcb791-d9d8-47a6-b9c6-a40f985c67e3" });
        }
    }
}
