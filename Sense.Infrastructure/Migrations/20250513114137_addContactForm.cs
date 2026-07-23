using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addContactForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactFormTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactFormTbls", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4703d665-8007-468c-b13e-e106a439f966", "AQAAAAIAAYagAAAAELBAy9kVbqp3Y3kVbsB/A30QsXbiGIHBLDTGCHqiVvY/MkFtVzrWfsDFDoUaf2HggQ==", "2fd3eb1f-f93f-4841-beaf-86d63de45c93" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 11, 41, 35, 369, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.CreateIndex(
                name: "IX_CartItemTbls_ProductId",
                table: "CartItemTbls",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItemTbls_ProductTbls_ProductId",
                table: "CartItemTbls",
                column: "ProductId",
                principalTable: "ProductTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItemTbls_ProductTbls_ProductId",
                table: "CartItemTbls");

            migrationBuilder.DropTable(
                name: "ContactFormTbls");

            migrationBuilder.DropIndex(
                name: "IX_CartItemTbls_ProductId",
                table: "CartItemTbls");

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
    }
}
