using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addImageForCategoriesAndImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "FreeMaintenanceOfferTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "CashbackOfferTbls",
                type: "nvarchar(max)",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "FreeMaintenanceOfferTbls");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "CashbackOfferTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03aaa29f-f48b-49d2-bc38-ea859479020c", "AQAAAAIAAYagAAAAEAfZ5UekwTcay4QGbkVCgPw+Sl0U+WODHWTu/3uczZAhol/Q59aJeJ7W3S4a6ltxMg==", "4e853513-283d-4de1-9d3d-bb21dd7d6512" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 249, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(63));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 9, 53, 57, 250, DateTimeKind.Utc).AddTicks(124));
        }
    }
}
