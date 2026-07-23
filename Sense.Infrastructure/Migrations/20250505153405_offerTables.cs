using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class offerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashbackOfferTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashbackType = table.Column<int>(type: "int", nullable: false),
                    CashbackVal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashbackOfferTbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreeMaintenanceOfferTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredAppointments = table.Column<int>(type: "int", nullable: false),
                    FreePeriodInDays = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeMaintenanceOfferTbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashbackOfferUsageTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashbackVal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CashbackOfferId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashbackOfferUsageTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashbackOfferUsageTbls_CashbackOfferTbls_CashbackOfferId",
                        column: x => x.CashbackOfferId,
                        principalTable: "CashbackOfferTbls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CashbackOfferUsageTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FreeMaintenanceEligibilityTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEligible = table.Column<bool>(type: "bit", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    ActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    FreeMaintenanceOfferId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeMaintenanceEligibilityTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeMaintenanceEligibilityTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FreeMaintenanceEligibilityTbls_FreeMaintenanceOfferTbls_FreeMaintenanceOfferId",
                        column: x => x.FreeMaintenanceOfferId,
                        principalTable: "FreeMaintenanceOfferTbls",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a68a8b57-053e-4fe9-937f-ce3097473fdd", "AQAAAAIAAYagAAAAENMfw7L3bcCaQ+sLeo1C7Huqx5WgJMqPpd+irGL/2gDfrzci5MfSb1bGZs6AmGXJjw==", "c760a592-6f5f-4736-860a-2d95edf5b0cd" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 15, 34, 2, 855, DateTimeKind.Utc).AddTicks(2374));

            migrationBuilder.CreateIndex(
                name: "IX_CashbackOfferUsageTbls_CashbackOfferId",
                table: "CashbackOfferUsageTbls",
                column: "CashbackOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CashbackOfferUsageTbls_CustomerId",
                table: "CashbackOfferUsageTbls",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeMaintenanceEligibilityTbls_CustomerId",
                table: "FreeMaintenanceEligibilityTbls",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeMaintenanceEligibilityTbls_FreeMaintenanceOfferId",
                table: "FreeMaintenanceEligibilityTbls",
                column: "FreeMaintenanceOfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashbackOfferUsageTbls");

            migrationBuilder.DropTable(
                name: "FreeMaintenanceEligibilityTbls");

            migrationBuilder.DropTable(
                name: "CashbackOfferTbls");

            migrationBuilder.DropTable(
                name: "FreeMaintenanceOfferTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65a881d5-6668-4ec7-8658-ccd082b99320", "AQAAAAIAAYagAAAAEIz8vHWYHtP9LKV+jS6hB0yxR8BAg/86MpdGiJ+kYCn1q8a6SRaI0XkRHX3xoiTlBw==", "0248ad61-a8a5-4a52-940e-b43bd4870977" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 50, 24, 157, DateTimeKind.Utc).AddTicks(5412));
        }
    }
}
