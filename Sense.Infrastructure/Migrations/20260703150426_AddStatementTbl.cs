using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatementTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatementTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementTbls", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "StatementTbls",
                columns: new[] { "Id", "CreatedAt", "IconClass", "IsActive", "IsDeleted", "ModifiedAt", "SortOrder", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 11, 54, 20, 608, DateTimeKind.Utc).AddTicks(9001), "bx bx-check-shield", true, false, null, 1, "منتجات موثوقة وخدمة تهتم بكل التفاصيل" },
                    { 2, new DateTime(2026, 1, 1, 11, 54, 20, 608, DateTimeKind.Utc).AddTicks(9002), "bx bx-package", true, false, null, 2, "توصيل سريع وآمن حتى باب منزلك" },
                    { 3, new DateTime(2026, 1, 1, 11, 54, 20, 608, DateTimeKind.Utc).AddTicks(9003), "bx bx-lock-alt", true, false, null, 3, "دفع آمن بوسائل متعددة" },
                    { 4, new DateTime(2026, 1, 1, 11, 54, 20, 608, DateTimeKind.Utc).AddTicks(9004), "bx bx-badge-check", true, false, null, 4, "منتجات أصلية من مورّدين موثوقين" },
                    { 5, new DateTime(2026, 1, 1, 11, 54, 20, 608, DateTimeKind.Utc).AddTicks(9005), "bx bx-headphone", true, false, null, 5, "دعم متواصل جاهز لمساعدتك في أي وقت" },
                    { 6, new DateTime(2026, 1, 1, 11, 54, 20, 608, DateTimeKind.Utc).AddTicks(9006), "bx bx-refresh", true, false, null, 6, "تشكيلة متجددة من أحدث المنتجات باستمرار" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatementTbls");
        }
    }
}
