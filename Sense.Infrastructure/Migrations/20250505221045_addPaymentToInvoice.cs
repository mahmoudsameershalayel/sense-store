using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPaymentToInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "MaintenanceRecordTbls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "MaintenanceRecordTbls",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ede36ff-4c6b-4baa-a055-4c2097503aa6", "AQAAAAIAAYagAAAAENpJgEDbxH2MnHOtE8M+JWGGdnPuQTA36h9edLYyK0fXtH2ne3sGtrA6vyv8qYmKig==", "476412b0-8d37-453e-985a-803f56043b5b" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6316));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "MaintenanceRecordTbls");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "MaintenanceRecordTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a68a8b57-053e-4fe9-937f-ce3097473fdd", "AQAAAAIAAYagAAAAENMfw7L3bcCaQ+sLeo1C7Huqx5WgJMqPpd+irGL/2gDfrzci5MfSb1bGZs6AmGXJjw==", "c760a592-6f5f-4736-860a-2d95edf5b0cd" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2374));
        }
    }
}
