using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeFiledName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductAmount",
                table: "CartItemTbls",
                newName: "ProductQuantity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51944608-1190-41da-90d4-fe416bf10cef", "AQAAAAIAAYagAAAAEEPaY8ieMGayhrv4wQNMAsVlFJgetVp/4UjZTrgaT01lH13hx+3UPdJZa2PXu4Oebw==", "9a678c8e-8bb3-4b97-8e53-ab05fd60bcb4" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6260));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "CartItemTbls",
                newName: "ProductAmount");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad1142e9-a2ed-428c-bd0e-95aafd986d48", "AQAAAAIAAYagAAAAEGZ+JqGvP7teimGiYPnDJv+v8bUZ0kEi5AUR0NIJ6Y6Y8KaD67kvgISsCPYdfk4lwA==", "582b3d8b-c333-4ec4-9006-1f158aef03c9" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1280));
        }
    }
}
