using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addOfferDisToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotalOfferDisValue",
                table: "OrderTbls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23026cec-9e8e-4f69-9219-43019ec419fb", "AQAAAAIAAYagAAAAEGtvnAH7eYamU71g30rJ81NOkWDMvitUbt8OP61I9oR6Bgkq8bvGHWdnPgmyJIckJg==", "c0bc3052-98c8-42ee-b89a-6aaf25e63484" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1464));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 14, 56, 18, 839, DateTimeKind.Utc).AddTicks(1473));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotalOfferDisValue",
                table: "OrderTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c2a32c9-57fe-4dc2-a839-914fb88c96f6", "AQAAAAIAAYagAAAAEAH8a7Px7cVfGSixtXYZhPeZu4Dm23BZt0OZBtr2Wy66foOGWClcUMTUP1TfA0uT+g==", "607e37ab-41a3-4028-ac1d-3024bd6021fe" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9169));
        }
    }
}
