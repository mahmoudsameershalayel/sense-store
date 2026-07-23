using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTbls_BrandTbls_BrandId",
                table: "AppointmentTbls");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "AppointmentTbls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69be97a8-5712-48b2-8879-16e411693e41", "AQAAAAIAAYagAAAAEKfPW7jBWCqOMw9xcC5GiYZtBXC5KNZ041oKF9b4zpdqaYhAG0R5N8o5i3T0tgb98g==", "03b1e971-7c1d-41a0-81cc-7619abbba392" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 8, 55, 34, 479, DateTimeKind.Utc).AddTicks(4059));

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTbls_BrandTbls_BrandId",
                table: "AppointmentTbls",
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

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "AppointmentTbls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51944608-1190-41da-90d4-fe416bf10cef", "AQAAAAIAAYagAAAAEEPaY8ieMGayhrv4wQNMAsVlFJgetVp/4UjZTrgaT01lH13hx+3UPdJZa2PXu4Oebw==", "9a678c8e-8bb3-4b97-8e53-ab05fd60bcb4" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 20, 10, 14, 878, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTbls_BrandTbls_BrandId",
                table: "AppointmentTbls",
                column: "BrandId",
                principalTable: "BrandTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
