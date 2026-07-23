using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeNameInAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentType",
                table: "AppointmentTbls",
                newName: "ServiceType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51af8496-0203-4987-afb3-21bece39b3b1", "AQAAAAIAAYagAAAAEDfSB5h5grG9sVktdakI6JzirAoGcpNdRiWkPR5zlOWgVCm+ynR75AgBYOY1/FBYig==", "4fe18f3e-a5eb-416e-a68a-4c05f63e1e84" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "AppointmentTbls",
                newName: "AppointmentType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e2f053f-eed4-49f4-b8e3-a3cd6a501596", "AQAAAAIAAYagAAAAEH0CVHWXAUZ2bmm6pUUpugjeeOijk8f3KglMLpfSIqWJovWSPJbphm2q6JSDSVdyNw==", "08122d45-e15b-42f8-8bf2-decf641e0a86" });
        }
    }
}
