using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeConstrains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTbls_BranchTbls_BranchId",
                table: "AppointmentTbls");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
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
                values: new object[] { "7e2f053f-eed4-49f4-b8e3-a3cd6a501596", "AQAAAAIAAYagAAAAEH0CVHWXAUZ2bmm6pUUpugjeeOijk8f3KglMLpfSIqWJovWSPJbphm2q6JSDSVdyNw==", "08122d45-e15b-42f8-8bf2-decf641e0a86" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTbls_BranchTbls_BranchId",
                table: "AppointmentTbls",
                column: "BranchId",
                principalTable: "BranchTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTbls_BranchTbls_BranchId",
                table: "AppointmentTbls");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
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
                values: new object[] { "744b7e56-a950-4657-82c1-ab8975f3dac9", "AQAAAAIAAYagAAAAEE76lv4/XeZ547eZF473TZScWgNdMgXnJMnxS/q3EGwAVQiwjBPQ+QO0NMgZu4mwOQ==", "ad592f76-95b4-43b7-a886-34a4411079c7" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTbls_BranchTbls_BranchId",
                table: "AppointmentTbls",
                column: "BranchId",
                principalTable: "BranchTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
