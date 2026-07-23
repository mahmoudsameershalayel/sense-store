using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDeliveryFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryFee",
                table: "OrderTbls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4262cd0d-2533-41ac-a6a9-e754629b1210", "AQAAAAIAAYagAAAAEPEdDJAohboWgjiMulejLEfSvb1EhHfqhf6DIIs4h8tMQmh/VNtB28PEWYLYo3Z5Tw==", "ecfd0155-c511-4e1a-bc6a-39cbccd2c9b8" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(6));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryFee",
                table: "OrderTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a73aee9-2700-465a-a053-242e81e457ac", "AQAAAAIAAYagAAAAEKjFDZMsHB62wl81AImVDLTsmKVN0Mwu2lzp5Kl6lwtRmpAHsGMkAtLCzUTK+sR+2w==", "a39d0aeb-1d86-4c1b-8f57-7ce6d1556fc3" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6417));
        }
    }
}
