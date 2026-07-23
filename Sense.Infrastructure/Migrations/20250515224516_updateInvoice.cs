using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbls_ProductTbls_ProductId",
                table: "InvoiceTbls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceTbls",
                table: "InvoiceTbls");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceTbls_ProductId",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "ProductCost",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InvoiceTbls");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "InvoiceTbls",
                newName: "InvoiceAmount");

            migrationBuilder.AlterColumn<decimal>(
                name: "LaborCost",
                table: "InvoiceTbls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<long>(
                name: "InvoiceNo",
                table: "InvoiceTbls",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceTbls",
                table: "InvoiceTbls",
                column: "InvoiceNo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5e4af63-a469-4cf8-b2bf-4e8d33f90c6e", "AQAAAAIAAYagAAAAEBYfxVv+CCQBd6yM6KxPA0fgZJpHUheR5ssw0GXWKeybe2CqTu9qty4j7ox3n4HmnA==", "c975dd71-75e2-48c9-aee4-23965475529e" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(929));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceTbls",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "InvoiceTbls");

            migrationBuilder.RenameColumn(
                name: "InvoiceAmount",
                table: "InvoiceTbls",
                newName: "TotalAmount");

            migrationBuilder.AlterColumn<decimal>(
                name: "LaborCost",
                table: "InvoiceTbls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InvoiceTbls",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InvoiceTbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "InvoiceTbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "InvoiceTbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "InvoiceTbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductCost",
                table: "InvoiceTbls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "InvoiceTbls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "InvoiceTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceTbls",
                table: "InvoiceTbls",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99bec809-25c0-4df7-8dd5-a7853499d032", "AQAAAAIAAYagAAAAEHql8uqbv/dt9Vs9Ky4k24ZKYwVdQktZpyfnr0wnLytgh8F3fYHH84OsvjlPJbi1ug==", "8d2d82d5-8d13-493f-81c4-2f101e7311e8" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTbls_ProductId",
                table: "InvoiceTbls",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbls_ProductTbls_ProductId",
                table: "InvoiceTbls",
                column: "ProductId",
                principalTable: "ProductTbls",
                principalColumn: "Id");
        }
    }
}
