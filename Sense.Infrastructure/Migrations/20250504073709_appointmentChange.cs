using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class appointmentChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CanceledReason",
                table: "AppointmentTbls",
                newName: "RejectReason");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d5e2550-961b-4e23-aa26-fc70a835cd76", "AQAAAAIAAYagAAAAEB8KMVu9Ar22+xnLyCg+rIqmXPFaOZGLS45CxvIbUyy2sqhgcLbv6iqVgwWf5cueUQ==", "3d02dfdb-4a96-47c9-a15c-23c8b58c7cba" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7206));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RejectReason",
                table: "AppointmentTbls",
                newName: "CanceledReason");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d0d1d9e-fb95-4796-90e3-e7d689c85c30", "AQAAAAIAAYagAAAAEOjxxbL4W/4h3l4aELkK8ZpTkxJLbf8ifT8gAlODwreHNYaW9s7fS4HIsUJRS9tVhQ==", "3919003e-4c9d-4339-8057-f7aeeebc8bfb" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1668));
        }
    }
}
