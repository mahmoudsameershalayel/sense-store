using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPerUserToCouponTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerUser",
                table: "CouponTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f42ef04-072e-4382-a617-e7b8d03ef318", "AQAAAAIAAYagAAAAEEXD7/PUCXkoZL4J0NkyZsIoJ7qJCUjCFLP5HQix5edKLluMJYIZJHBPxxVAm0ghEg==", "ebaf881b-754c-4c5b-8fee-83e788f3cceb" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 24, 6, 26, 14, 101, DateTimeKind.Utc).AddTicks(3436));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerUser",
                table: "CouponTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8b20034-3a3c-4b37-9654-2350ceddbdd6", "AQAAAAIAAYagAAAAENBHM0+Hyy7lST/9Vs3ABCNpGmqV0JuB8pV9FDMRDTCM2ImoW8c+JLshBXmJOjt9dg==", "763a1c41-19e2-40db-b66c-c25d742cf8a1" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8475));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 22, 9, 15, 29, 411, DateTimeKind.Utc).AddTicks(8516));
        }
    }
}
