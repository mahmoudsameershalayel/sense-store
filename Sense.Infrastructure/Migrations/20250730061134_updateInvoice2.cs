using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateInvoice2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaborCost",
                table: "InvoiceTbls");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceType",
                table: "InvoiceTbls",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f19cf70-05f9-496f-b8cd-fb92258886b6", "AQAAAAIAAYagAAAAEO1pCffixsnHZtiaEKFqxPA5f8yKKO+ans7CdKUMasBy3OXlJWH3Nj0D1HaEbrzpQw==", "ccb4e5d1-7606-4fdf-a821-b27728fbeafd" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8774));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "InvoiceTbls");

            migrationBuilder.AddColumn<decimal>(
                name: "LaborCost",
                table: "InvoiceTbls",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1807dd27-f520-42df-a2e9-78bcb4f73fea", "AQAAAAIAAYagAAAAEHHnilHZucP/PF08I1HrBYtWhjHOutNW5B2r9PJynlGd7a7Elcp6f/kEcMdSM+zdrg==", "59c0bd86-ecb0-47f2-8d2f-8fb589aefbe0" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8027));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 10, 2, 12, 91, DateTimeKind.Utc).AddTicks(8055));
        }
    }
}
