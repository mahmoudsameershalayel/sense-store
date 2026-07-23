using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFieldToCashback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApplyOnLaborCost",
                table: "CashbackOfferTbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplyOnSparePart",
                table: "CashbackOfferTbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplyOnStore",
                table: "CashbackOfferTbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ed8a789-d8e3-441d-803a-5407d0ae5928", "AQAAAAIAAYagAAAAECHwg+f1OaMBcHBQjzuyN3Xb46h7BzD/DyEze3Hbmaiz8mBeThBz4nJ/Np19jRDmOg==", "037253d5-29f9-4782-bb68-564a719b1feb" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5073));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5113));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5338));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 14, 50, 305, DateTimeKind.Utc).AddTicks(5380));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApplyOnLaborCost",
                table: "CashbackOfferTbls");

            migrationBuilder.DropColumn(
                name: "IsApplyOnSparePart",
                table: "CashbackOfferTbls");

            migrationBuilder.DropColumn(
                name: "IsApplyOnStore",
                table: "CashbackOfferTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "965648b3-4baf-4622-97e9-d6cd031701e0", "AQAAAAIAAYagAAAAEIcViLQsbs3Z5wLZLDq/CDmT3DY597MQcFhGJdogcx5W8b98DWDqARTwju43FPkDPw==", "23f3a773-feba-4653-b661-f06aa6da41e1" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1425));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1515));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1564));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 9, 11, 12, 29, 513, DateTimeKind.Utc).AddTicks(1575));
        }
    }
}
