using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newAppointmentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "AppointmentTbls",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad1142e9-a2ed-428c-bd0e-95aafd986d48", "AQAAAAIAAYagAAAAEGZ+JqGvP7teimGiYPnDJv+v8bUZ0kEi5AUR0NIJ6Y6Y8KaD67kvgISsCPYdfk4lwA==", "582b3d8b-c333-4ec4-9006-1f158aef03c9" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1279));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 18, 13, 49, 292, DateTimeKind.Utc).AddTicks(1280));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTbls_SupervisorId",
                table: "AppointmentTbls",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTbls_SupervisorTbl_SupervisorId",
                table: "AppointmentTbls",
                column: "SupervisorId",
                principalTable: "SupervisorTbl",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTbls_SupervisorTbl_SupervisorId",
                table: "AppointmentTbls");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentTbls_SupervisorId",
                table: "AppointmentTbls");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "AppointmentTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d1f8332-68e1-456d-a1d6-4159451b1f07", "AQAAAAIAAYagAAAAECwf+5Gt8ELmTZvjpo3PBPYrybAaeJK8XC+/43V1TuUZD5cxFtnkiaAzIywcGncbDA==", "5b541bd5-cd89-4571-be34-7ce14368b940" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6177));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 10, 30, 28, 982, DateTimeKind.Utc).AddTicks(6191));
        }
    }
}
