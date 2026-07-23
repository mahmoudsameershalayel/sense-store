using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addToCashBackUsage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceRecordId",
                table: "CashbackOfferUsageTbls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CashbackOfferUsageTbls",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f633c077-be02-4b27-a441-f666a8a4abfa", "AQAAAAIAAYagAAAAEF+uW7RxF4fy9yN1ywLLmEEDat/WKacodrv6fV//Abe+o3F1wmGbP9ElkdOsvQMvVA==", "55cdd5ca-dbe7-445c-a865-b626f6b10de0" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3937));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3954));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 11, 6, 52, 28, 228, DateTimeKind.Utc).AddTicks(3955));

            migrationBuilder.CreateIndex(
                name: "IX_CashbackOfferUsageTbls_MaintenanceRecordId",
                table: "CashbackOfferUsageTbls",
                column: "MaintenanceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CashbackOfferUsageTbls_OrderId",
                table: "CashbackOfferUsageTbls",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashbackOfferUsageTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                table: "CashbackOfferUsageTbls",
                column: "MaintenanceRecordId",
                principalTable: "MaintenanceRecordTbls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CashbackOfferUsageTbls_OrderTbls_OrderId",
                table: "CashbackOfferUsageTbls",
                column: "OrderId",
                principalTable: "OrderTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashbackOfferUsageTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                table: "CashbackOfferUsageTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_CashbackOfferUsageTbls_OrderTbls_OrderId",
                table: "CashbackOfferUsageTbls");

            migrationBuilder.DropIndex(
                name: "IX_CashbackOfferUsageTbls_MaintenanceRecordId",
                table: "CashbackOfferUsageTbls");

            migrationBuilder.DropIndex(
                name: "IX_CashbackOfferUsageTbls_OrderId",
                table: "CashbackOfferUsageTbls");

            migrationBuilder.DropColumn(
                name: "MaintenanceRecordId",
                table: "CashbackOfferUsageTbls");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CashbackOfferUsageTbls");

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
    }
}
