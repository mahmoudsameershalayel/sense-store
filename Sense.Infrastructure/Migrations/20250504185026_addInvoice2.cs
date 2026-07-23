using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addInvoice2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderEznNo",
                table: "OrderTbls");

            migrationBuilder.DropColumn(
                name: "EznDate",
                table: "OrderDetailsTbls");

            migrationBuilder.RenameColumn(
                name: "OrderEznNetValue",
                table: "OrderTbls",
                newName: "OrderNetValue");

            migrationBuilder.RenameColumn(
                name: "OrderEznMemo",
                table: "OrderTbls",
                newName: "OrderMemo");

            migrationBuilder.RenameColumn(
                name: "OrderEznDate",
                table: "OrderTbls",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "EznTime",
                table: "OrderDetailsTbls",
                newName: "OrderDate");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65a881d5-6668-4ec7-8658-ccd082b99320", "AQAAAAIAAYagAAAAEIz8vHWYHtP9LKV+jS6hB0yxR8BAg/86MpdGiJ+kYCn1q8a6SRaI0XkRHX3xoiTlBw==", "0248ad61-a8a5-4a52-940e-b43bd4870977" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5412));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderNetValue",
                table: "OrderTbls",
                newName: "OrderEznNetValue");

            migrationBuilder.RenameColumn(
                name: "OrderMemo",
                table: "OrderTbls",
                newName: "OrderEznMemo");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "OrderTbls",
                newName: "OrderEznDate");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "OrderDetailsTbls",
                newName: "EznTime");

            migrationBuilder.AddColumn<long>(
                name: "OrderEznNo",
                table: "OrderTbls",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EznDate",
                table: "OrderDetailsTbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "483dedb0-7d81-4e61-8a6e-0327766ed4ff", "AQAAAAIAAYagAAAAEEYMEQfRb/l48KIR02DvUU35VqjPXwtqfs/6HMb1pRXNKu7+XI/uXQ+uT9bCy3yBOA==", "90468071-0ba6-4c3e-b67d-381249d2b4d3" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3069));
        }
    }
}
