using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPointTransactionTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxRedeemPoints",
                table: "centerSettingTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinRedeemPoints",
                table: "centerSettingTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PointsToSARRate",
                table: "centerSettingTbls",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PointsTransactionTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PointsRedeemed = table.Column<int>(type: "int", nullable: false),
                    AmountDeducted = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsToSARRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceRecordId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsTransactionTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointsTransactionTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointsTransactionTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                        column: x => x.MaintenanceRecordId,
                        principalTable: "MaintenanceRecordTbls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PointsTransactionTbls_OrderTbls_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderTbls",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3318edd2-5c12-44eb-94f9-3e433bfd1c53", "AQAAAAIAAYagAAAAEAwWtt9zFuoAcYTP9WMS8pHNxgg6n0EiLPQq2YFbwkKuVQ0EVyYC03tpZB4tRSll+Q==", "5c16ad3a-88d8-404a-a32d-c2aedf3e7480" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.CreateIndex(
                name: "IX_PointsTransactionTbls_CustomerId",
                table: "PointsTransactionTbls",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsTransactionTbls_MaintenanceRecordId",
                table: "PointsTransactionTbls",
                column: "MaintenanceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsTransactionTbls_OrderId",
                table: "PointsTransactionTbls",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointsTransactionTbls");

            migrationBuilder.DropColumn(
                name: "MaxRedeemPoints",
                table: "centerSettingTbls");

            migrationBuilder.DropColumn(
                name: "MinRedeemPoints",
                table: "centerSettingTbls");

            migrationBuilder.DropColumn(
                name: "PointsToSARRate",
                table: "centerSettingTbls");

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
        }
    }
}
