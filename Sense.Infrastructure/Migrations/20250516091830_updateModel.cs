using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTbls_BrandTypeTbls_BrandTypeId",
                table: "ProductTbls");

            migrationBuilder.DropTable(
                name: "BrandTypeTbls");

            migrationBuilder.RenameColumn(
                name: "BrandTypeId",
                table: "ProductTbls",
                newName: "ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTbls_BrandTypeId",
                table: "ProductTbls",
                newName: "IX_ProductTbls_ModelId");

            migrationBuilder.CreateTable(
                name: "ModelTbls",
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
                    table.PrimaryKey("PK_ModelTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelTbls_BrandTbls_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BrandTbls",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ModelTbls_BrandId",
                table: "ModelTbls",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTbls_ModelTbls_ModelId",
                table: "ProductTbls",
                column: "ModelId",
                principalTable: "ModelTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTbls_ModelTbls_ModelId",
                table: "ProductTbls");

            migrationBuilder.DropTable(
                name: "ModelTbls");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "ProductTbls",
                newName: "BrandTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTbls_ModelId",
                table: "ProductTbls",
                newName: "IX_ProductTbls_BrandTypeId");

            migrationBuilder.CreateTable(
                name: "BrandTypeTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                values: new object[] { "e5e4af63-a469-4cf8-b2bf-4e8d33f90c6e", "AQAAAAIAAYagAAAAEBYfxVv+CCQBd6yM6KxPA0fgZJpHUheR5ssw0GXWKeybe2CqTu9qty4j7ox3n4HmnA==", "c975dd71-75e2-48c9-aee4-23965475529e" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 15, 22, 45, 14, 43, DateTimeKind.Utc).AddTicks(929));

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
    }
}
