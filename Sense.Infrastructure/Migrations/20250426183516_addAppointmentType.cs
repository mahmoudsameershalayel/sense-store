using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addAppointmentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentType",
                table: "AppointmentTbls",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "050b6cf9-b7a8-4e72-98e5-4aba010a85c8", "AQAAAAIAAYagAAAAEMH+BprzL15f3yY15OWprz5l+KIZpp+2C+S9cCHktlU/GQKhW/rqRJKT90iTmKa12A==", "824c81c3-fbdb-45c1-acb0-4c4f882a8860" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentType",
                table: "AppointmentTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20ced901-dfb6-41da-b5dc-5646bc929367", "AQAAAAIAAYagAAAAEMIikX0IwUQ3LJ4cuWe3EkAonbbOpuMn1P9XoZ3HK76P87yj2y5/1WHKVZfTOameJQ==", "20c88521-3b6b-43b0-bd5f-a95e212f43ce" });
        }
    }
}
