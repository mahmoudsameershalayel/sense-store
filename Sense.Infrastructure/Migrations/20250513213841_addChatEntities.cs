using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addChatEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessageTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessageTbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionTbls",
                columns: table => new
                {
                    ConnectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionTbls", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_ConnectionTbls_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a73aee9-2700-465a-a053-242e81e457ac", "AQAAAAIAAYagAAAAEKjFDZMsHB62wl81AImVDLTsmKVN0Mwu2lzp5Kl6lwtRmpAHsGMkAtLCzUTK+sR+2w==", "a39d0aeb-1d86-4c1b-8f57-7ce6d1556fc3" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 13, 21, 38, 38, 514, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionTbls_UserId",
                table: "ConnectionTbls",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessageTbls");

            migrationBuilder.DropTable(
                name: "ConnectionTbls");

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
        }
    }
}
