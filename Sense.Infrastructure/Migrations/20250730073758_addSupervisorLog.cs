using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSupervisorLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupervisorActivityLogTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityType = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorActivityLogTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisorActivityLogTbls_SupervisorTbl_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "SupervisorTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7257e9a9-ca27-4670-b2a5-ca31cedeaa2c", "AQAAAAIAAYagAAAAELschCkQu6b7P2VgJTvherA6ZydukCf5PHSdAJiSVwPFFDIA1IWXrLQlKzyMSTfBVg==", "51f070fe-bee8-4750-ab99-9c77d9a4abdf" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5499));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5501));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5511));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5538));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5539));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5542));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5544));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5545));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5546));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5549));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 7, 37, 55, 500, DateTimeKind.Utc).AddTicks(5550));

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorActivityLogTbls_SupervisorId",
                table: "SupervisorActivityLogTbls",
                column: "SupervisorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupervisorActivityLogTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f19cf70-05f9-496f-b8cd-fb92258886b6", "AQAAAAIAAYagAAAAEO1pCffixsnHZtiaEKFqxPA5f8yKKO+ans7CdKUMasBy3OXlJWH3Nj0D1HaEbrzpQw==", "ccb4e5d1-7606-4fdf-a821-b27728fbeafd" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 30, 6, 11, 33, 587, DateTimeKind.Utc).AddTicks(8774));
        }
    }
}
