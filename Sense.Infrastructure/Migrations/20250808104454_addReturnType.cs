using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addReturnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturType",
                table: "CashbackOfferTbls",
                newName: "ReturnType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5b7ec7d-06b8-4f8f-a2c6-13f368a7ce32", "AQAAAAIAAYagAAAAENxpXeDbpOVCwU8QuX4H//5HrmGOlNMEbR9kHwLL+to9hsOeygaaw4Qq1Fir0t+Hlw==", "20ac4fc0-7b85-48d6-add9-1c3e99189f43" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5492));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5527));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5532));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 8, 10, 44, 52, 86, DateTimeKind.Utc).AddTicks(5537));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnType",
                table: "CashbackOfferTbls",
                newName: "ReturType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13781fc3-5a9c-4f7d-b7fc-ae70d530b25c", "AQAAAAIAAYagAAAAEGjeXl5YT8ClSLfWbq0rlDCZAPa5GdTKshItZW6zuhTETMEvswJY5IQBJsJbdyvphA==", "815cb314-0943-4b58-a6f1-b73e284f244e" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1953));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 7, 19, 54, 31, 74, DateTimeKind.Utc).AddTicks(2213));
        }
    }
}
