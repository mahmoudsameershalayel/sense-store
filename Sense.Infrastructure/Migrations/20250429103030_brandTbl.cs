using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class brandTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "ProductTbls");

            migrationBuilder.DropColumn(
                name: "AppointmentDetails",
                table: "AppointmentTbls");

            migrationBuilder.RenameColumn(
                name: "VehicleModel",
                table: "AppointmentTbls",
                newName: "ModelYear");

            migrationBuilder.RenameColumn(
                name: "VehicleBrand",
                table: "AppointmentTbls",
                newName: "Details");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "ProductTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "AppointmentTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BrandTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTbls", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d1f8332-68e1-456d-a1d6-4159451b1f07", "AQAAAAIAAYagAAAAECwf+5Gt8ELmTZvjpo3PBPYrybAaeJK8XC+/43V1TuUZD5cxFtnkiaAzIywcGncbDA==", "5b541bd5-cd89-4571-be34-7ce14368b940" });

            migrationBuilder.InsertData(
                table: "BrandTbls",
                columns: new[] { "Id", "CreatedAt", "IsActive", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6166), true, false, null, "Toyota" },
                    { 2, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6173), true, false, null, "Nissan" },
                    { 3, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6174), true, false, null, "Mercedes" },
                    { 4, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6175), true, false, null, "BMW" },
                    { 5, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6176), true, false, null, "Audi" },
                    { 6, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6177), true, false, null, "Honda" },
                    { 7, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6178), true, false, null, "Ford" },
                    { 8, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6179), true, false, null, "Chevrolet" },
                    { 9, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6180), true, false, null, "Hyundai" },
                    { 10, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6181), true, false, null, "Kia" },
                    { 11, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6182), true, false, null, "Lexus" },
                    { 12, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6183), true, false, null, "Jeep" },
                    { 13, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6184), true, false, null, "Mazda" },
                    { 14, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6185), true, false, null, "Mitsubishi" },
                    { 15, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6186), true, false, null, "Porsche" },
                    { 16, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6187), true, false, null, "Rolls Royce" },
                    { 17, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6188), true, false, null, "Land Rover" },
                    { 18, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6189), true, false, null, "Suzuki" },
                    { 19, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6190), true, false, null, "Tesla" },
                    { 20, new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6191), true, false, null, "Dodge" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTbls_BrandId",
                table: "ProductTbls",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTbls_BrandId",
                table: "AppointmentTbls",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTbls_BrandTbls_BrandId",
                table: "AppointmentTbls",
                column: "BrandId",
                principalTable: "BrandTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTbls_BrandTbls_BrandId",
                table: "ProductTbls",
                column: "BrandId",
                principalTable: "BrandTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTbls_BrandTbls_BrandId",
                table: "AppointmentTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTbls_BrandTbls_BrandId",
                table: "ProductTbls");

            migrationBuilder.DropTable(
                name: "BrandTbls");

            migrationBuilder.DropIndex(
                name: "IX_ProductTbls_BrandId",
                table: "ProductTbls");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentTbls_BrandId",
                table: "AppointmentTbls");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "ProductTbls");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "AppointmentTbls");

            migrationBuilder.RenameColumn(
                name: "ModelYear",
                table: "AppointmentTbls",
                newName: "VehicleModel");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "AppointmentTbls",
                newName: "VehicleBrand");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "ProductTbls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppointmentDetails",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51af8496-0203-4987-afb3-21bece39b3b1", "AQAAAAIAAYagAAAAEDfSB5h5grG9sVktdakI6JzirAoGcpNdRiWkPR5zlOWgVCm+ynR75AgBYOY1/FBYig==", "4fe18f3e-a5eb-416e-a68a-4c05f63e1e84" });
        }
    }
}
