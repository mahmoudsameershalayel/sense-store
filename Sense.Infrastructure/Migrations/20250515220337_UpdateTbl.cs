using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandTypeId",
                table: "ProductTbls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BrandTypeTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTypeTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandTypeTbls_BrandTbls_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BrandTbls",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99bec809-25c0-4df7-8dd5-a7853499d032", "AQAAAAIAAYagAAAAEHql8uqbv/dt9Vs9Ky4k24ZKYwVdQktZpyfnr0wnLytgh8F3fYHH84OsvjlPJbi1ug==", "8d2d82d5-8d13-493f-81c4-2f101e7311e8" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 3, 33, 912, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.CreateIndex(
                name: "IX_ProductTbls_BrandTypeId",
                table: "ProductTbls",
                column: "BrandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTypeTbls_BrandId",
                table: "BrandTypeTbls",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTbls_BrandTypeTbls_BrandTypeId",
                table: "ProductTbls",
                column: "BrandTypeId",
                principalTable: "BrandTypeTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTbls_BrandTypeTbls_BrandTypeId",
                table: "ProductTbls");

            migrationBuilder.DropTable(
                name: "BrandTypeTbls");

            migrationBuilder.DropIndex(
                name: "IX_ProductTbls_BrandTypeId",
                table: "ProductTbls");

            migrationBuilder.DropColumn(
                name: "BrandTypeId",
                table: "ProductTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4262cd0d-2533-41ac-a6a9-e754629b1210", "AQAAAAIAAYagAAAAEPEdDJAohboWgjiMulejLEfSvb1EhHfqhf6DIIs4h8tMQmh/VNtB28PEWYLYo3Z5Tw==", "ecfd0155-c511-4e1a-bc6a-39cbccd2c9b8" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 131, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 8, 48, 27, 132, DateTimeKind.Utc).AddTicks(6));
        }
    }
}
