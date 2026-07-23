using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editInAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VehicleBrand",
                table: "AppointmentTbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eec2c6f-0f4a-4e5f-855f-689b14157696", "AQAAAAIAAYagAAAAECV0eXk9xBR8G+jqZYvsig5VuwuPLKslSyAo0bKzakQzj5nq2Rk84mdnvODnS1xxsw==", "b8f94b51-ce85-48f5-92ca-dafc539b9871" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VehicleBrand",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "050b6cf9-b7a8-4e72-98e5-4aba010a85c8", "AQAAAAIAAYagAAAAEMH+BprzL15f3yY15OWprz5l+KIZpp+2C+S9cCHktlU/GQKhW/rqRJKT90iTmKa12A==", "824c81c3-fbdb-45c1-acb0-4c4f882a8860" });
        }
    }
}
