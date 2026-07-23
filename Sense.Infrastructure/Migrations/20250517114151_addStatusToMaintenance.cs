using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addStatusToMaintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MaintenanceRecordTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PhoneVerificationTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneVerificationTbls", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "850c06f8-735a-4f69-a5c0-b57255ad08d2", "AQAAAAIAAYagAAAAECKHzVkEhkem047JKM6DIjX1zLmKejfTQKnw2Ne/t+uLPNNg6Hhrge05a/OviLueiw==", "b2a42d8e-7c96-427e-99f2-210d3114364a" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 17, 11, 41, 48, 637, DateTimeKind.Utc).AddTicks(5942));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneVerificationTbls");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MaintenanceRecordTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1054c84e-daf3-4c95-8eee-f3ef44aea622", "AQAAAAIAAYagAAAAEBUjp20m6kX19UXwuVIKpEqxCGDeAZUxHhUR1AJZhTDfjZ9TrwVpRsAIwxJ3CNms3g==", "6f348565-5d13-4163-ba97-56164b051b5f" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 10, 29, 23, 136, DateTimeKind.Utc).AddTicks(9731));
        }
    }
}
