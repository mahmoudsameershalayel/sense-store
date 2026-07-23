using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPromo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignUrl",
                table: "MarketingCampaignTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "949acfc9-34f0-4459-8b68-aecb96ee8dd2", "AQAAAAIAAYagAAAAEKhKRnnadareaqeX1HLPobriEqH2xlxb2PjBeHwr4tSR246wCfEQRhSwJC9bNjGsYQ==", "b33e1396-5a28-4622-933c-5f6f360cf6f0" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 50, 21, 823, DateTimeKind.Utc).AddTicks(2300));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CampaignUrl",
                table: "MarketingCampaignTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5a87790-d0a1-491f-9141-1656aff805fb", "AQAAAAIAAYagAAAAEHGvgqA674TxtQ+9RWMsQr/X6+CFTr7YBfCdPV3zf+aEGH9xrrOfGi0cbXxoPWlQ2Q==", "cc97c01e-0654-4ef3-88a5-1adf6669a974" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1253));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1256));
        }
    }
}
