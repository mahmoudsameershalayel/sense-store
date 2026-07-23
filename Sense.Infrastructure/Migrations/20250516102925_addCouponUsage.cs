using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCouponUsage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "AppointmentTbls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CouponUsageTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponUsageTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponUsageTbls_CouponTbls_CouponId",
                        column: x => x.CouponId,
                        principalTable: "CouponTbls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CouponUsageTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTbls_ModelId",
                table: "AppointmentTbls",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponUsageTbls_CouponId",
                table: "CouponUsageTbls",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponUsageTbls_CustomerId",
                table: "CouponUsageTbls",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTbls_ModelTbls_ModelId",
                table: "AppointmentTbls",
                column: "ModelId",
                principalTable: "ModelTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTbls_ModelTbls_ModelId",
                table: "AppointmentTbls");

            migrationBuilder.DropTable(
                name: "CouponUsageTbls");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentTbls_ModelId",
                table: "AppointmentTbls");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "AppointmentTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8ebc10f-c1c0-40d5-840c-d78de20dedbe", "AQAAAAIAAYagAAAAEJxdm1WdpOlkOY/ueUQIMNeG3mmKQAwYRxEVIJa+1jqtQmM3wJIzguiqM5dOsExuvQ==", "afa96a28-80e5-4693-8d4f-a55e29b0c979" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 207, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 208, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 208, DateTimeKind.Utc).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 16, 9, 18, 28, 208, DateTimeKind.Utc).AddTicks(2));
        }
    }
}
