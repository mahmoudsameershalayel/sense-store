using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeImageFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "ServiceTbls",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "ProductTbls",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "CategoryTbls",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "BackgroundImagePath",
                table: "BannerTbls",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "AspNetUsers",
                newName: "ImageURL");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36b9cf56-2145-47c2-85c2-2b45f8276bf0", "AQAAAAIAAYagAAAAEG2eJdIURo6nuOzkceIJFVEKTa83N1YD68+J2NC7/9EdHWDwCplSLe8P2WLTABKcrg==", "8de6d3d5-f385-4823-b071-bcccc690e94f" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4567));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "ServiceTbls",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "ProductTbls",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "CategoryTbls",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "BannerTbls",
                newName: "BackgroundImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "AspNetUsers",
                newName: "ImagePath");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71032fe0-eafd-4a02-9cf1-8c0f92076b51", "AQAAAAIAAYagAAAAEB27vJhYjITcww+DmURoU097JWMijAvjaYp9zISy+6PzevUZ0XeD0/pE7DhNRDLiXw==", "eb097601-86b0-403e-87af-09cdc5ab0fe5" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1705));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1708));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1724));
        }
    }
}
