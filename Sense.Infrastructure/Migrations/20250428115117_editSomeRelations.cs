using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editSomeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "SupervisorTbl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "ImagePath", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d19e6bb8-78b8-4f78-b3bf-9aa69044a682", null, "AQAAAAIAAYagAAAAENtbSuJyxGBkGfrg68Uv1NgGbPSruM8tlasbVFIJveXtTXx7wuR2g1YgC/IARL8XYQ==", "bdbfaf14-7093-4a40-90c4-814240ba8f54" });

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorTbl_BranchId",
                table: "SupervisorTbl",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorTbl_BranchTbls_BranchId",
                table: "SupervisorTbl",
                column: "BranchId",
                principalTable: "BranchTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorTbl_BranchTbls_BranchId",
                table: "SupervisorTbl");

            migrationBuilder.DropIndex(
                name: "IX_SupervisorTbl_BranchId",
                table: "SupervisorTbl");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "SupervisorTbl");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f3e922d-c8f6-4b31-8525-ca59d2ced2d3", "AQAAAAIAAYagAAAAEJtiw5YpfNxEw5oBWUnMJE0QE/XeQf71oN/FdcEbRnwQOgXNeuP3J5PHHohXG6ZAag==", "9d6d14fa-5b09-4556-9055-bea217185d2e" });
        }
    }
}
