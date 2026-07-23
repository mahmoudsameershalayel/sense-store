using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTechsupportTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRecordTbls_AppointmentId",
                table: "MaintenanceRecordTbls");

            migrationBuilder.CreateTable(
                name: "TechSupportTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechSupportTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechSupportTbls_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edb2f88e-9a0d-4694-b559-6d5183d869ad",
                column: "ConcurrencyStamp",
                value: "edb2f88e-9a0d-4694-b559-6d5183d869ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "456743f7-8ce4-42tg-afbf-59f706d72cf6", "456743f7-8ce4-42tg-afbf-59f706d72cf6", "TechSupport", "TECHSUPPORT" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc754624-de7f-4a74-b8cd-9f696547f4f0", "AQAAAAIAAYagAAAAEILPjlGASjmWnIrWic9wCTjuTHSFieFN8Y4mp8lE9JddqQrBbeSmOSDkSNfZaWg6Aw==", "14302610-236d-461a-b0d5-f9eca62c7142" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 21, 8, 2, 24, 411, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecordTbls_AppointmentId",
                table: "MaintenanceRecordTbls",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechSupportTbls_ApplicationUserId",
                table: "TechSupportTbls",
                column: "ApplicationUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechSupportTbls");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRecordTbls_AppointmentId",
                table: "MaintenanceRecordTbls");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "456743f7-8ce4-42tg-afbf-59f706d72cf6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edb2f88e-9a0d-4694-b559-6d5183d869ad",
                column: "ConcurrencyStamp",
                value: "d7985763-4de6-46bb-92c6-e5d639da6243");

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

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecordTbls_AppointmentId",
                table: "MaintenanceRecordTbls",
                column: "AppointmentId");
        }
    }
}
