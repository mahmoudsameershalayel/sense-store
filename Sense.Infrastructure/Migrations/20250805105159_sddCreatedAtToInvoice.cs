using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sddCreatedAtToInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InvoiceTbls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98e99094-b40b-4c31-8e07-ced0596135b5", "AQAAAAIAAYagAAAAEE8Olk5SVx9lql/+HY2ARZYrFp/8rlGrsmofuwwtdZfNYLN/y3xAdPdbIVKzMrL62g==", "8c3e4fd5-3eac-4fc6-8321-cc443c144966" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7063));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 5, 10, 51, 57, 876, DateTimeKind.Utc).AddTicks(7270));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InvoiceTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7257e9a9-ca27-4670-b2a5-ca31cedeaa2c", "AQAAAAIAAYagAAAAELschCkQu6b7P2VgJTvherA6ZydukCf5PHSdAJiSVwPFFDIA1IWXrLQlKzyMSTfBVg==", "51f070fe-bee8-4750-ab99-9c77d9a4abdf" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5501));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5511));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5538));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5539));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5542));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5544));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5545));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5546));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5549));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5550));
        }
    }
}
