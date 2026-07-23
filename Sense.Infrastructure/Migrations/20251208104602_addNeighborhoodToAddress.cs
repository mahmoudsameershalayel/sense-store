using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNeighborhoodToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "AddressTbls",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eddbacf7-ba82-4ea2-9153-be42907f5744", "AQAAAAIAAYagAAAAEA22uVVjS52XQ+70UbHV1gc30lR9iKmULL6E4byaV7gnp6aeA8fid5uMJ/AEMCv+hg==", "a0fd4c47-d44d-4dca-99dc-f7c6505a01b3" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1239));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1317));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1319));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1324));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 8, 10, 45, 57, 103, DateTimeKind.Utc).AddTicks(1377));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "AddressTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d06190-bf5c-4386-801e-d84361267ffd", "AQAAAAIAAYagAAAAEEM4XPd9qTnCq3zpvBn1E9CUHByHkgaTqYWMJMDuZCi55RViN+EHa857Z7a25GzQ0Q==", "39d98dc0-0f4a-415e-966b-8af48ec97156" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2825));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 18, 26, 46, 454, DateTimeKind.Utc).AddTicks(3072));
        }
    }
}
