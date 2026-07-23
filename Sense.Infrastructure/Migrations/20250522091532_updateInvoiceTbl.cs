using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateInvoiceTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Drop PK constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceTbls",
                table: "InvoiceTbls");

            // 2. Add a temporary column without identity
            migrationBuilder.AddColumn<long>(
                name: "InvoiceNo_Temp",
                table: "InvoiceTbls",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            // 3. Copy data from old column to temp column
            migrationBuilder.Sql("UPDATE InvoiceTbls SET InvoiceNo_Temp = InvoiceNo");

            // 4. Drop old column (with identity)
            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "InvoiceTbls");

            // 5. Rename temp column to original name
            migrationBuilder.RenameColumn(
                name: "InvoiceNo_Temp",
                table: "InvoiceTbls",
                newName: "InvoiceNo");

            // 6. Add PK constraint again on new column
            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceTbls",
                table: "InvoiceTbls",
                column: "InvoiceNo");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "InvoiceNo",
                table: "InvoiceTbls",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc754624-de7f-4a74-b8cd-9f696547f4f0", "AQAAAAIAAYagAAAAEILPjlGASjmWnIrWic9wCTjuTHSFieFN8Y4mp8lE9JddqQrBbeSmOSDkSNfZaWg6Aw==", "14302610-236d-461a-b0d5-f9eca62c7142" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7103));
        }
    }
}
