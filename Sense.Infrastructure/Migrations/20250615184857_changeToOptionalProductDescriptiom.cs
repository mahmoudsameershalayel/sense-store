using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeToOptionalProductDescriptiom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "401b7758-03cb-4a0f-80b8-a91fe25363f9", "AQAAAAIAAYagAAAAECKik8XpXTh/56g1LmnVg2pgVUV19NJmvfxC3KHrzaBZf+9+mEFjSQp60YrHHL5aew==", "89007ffe-2cfb-405e-8262-ea0f631ff517" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 15, 18, 48, 54, 835, DateTimeKind.Utc).AddTicks(9627));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21a77620-68bc-4a92-9ebc-72a2decf421e", "AQAAAAIAAYagAAAAELpfwInZtZ0XTbJojgHpDjEcTcPMnFha99aIC6AMxf9PP+6tjNAgr7c/bwfC8GGUbA==", "bcc379a3-26c5-4991-ba54-a7dd8deeb100" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 11, 10, 33, 19, 467, DateTimeKind.Utc).AddTicks(8436));
        }
    }
}
