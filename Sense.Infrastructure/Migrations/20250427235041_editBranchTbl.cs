using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editBranchTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BranchCity",
                table: "BranchTbls",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "BranchAddress",
                table: "BranchTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "BranchTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CloseAtTime",
                table: "BranchTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "BranchTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "BranchTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenAtTime",
                table: "BranchTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f3e922d-c8f6-4b31-8525-ca59d2ced2d3", "AQAAAAIAAYagAAAAEJtiw5YpfNxEw5oBWUnMJE0QE/XeQf71oN/FdcEbRnwQOgXNeuP3J5PHHohXG6ZAag==", "9d6d14fa-5b09-4556-9055-bea217185d2e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchAddress",
                table: "BranchTbls");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "BranchTbls");

            migrationBuilder.DropColumn(
                name: "CloseAtTime",
                table: "BranchTbls");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "BranchTbls");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "BranchTbls");

            migrationBuilder.DropColumn(
                name: "OpenAtTime",
                table: "BranchTbls");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "BranchTbls",
                newName: "BranchCity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "951d9f2a-a753-4902-b4cb-1cc678e597d4", "AQAAAAIAAYagAAAAEHxkh6nOVL7ricwN72hFS8oUCc/STpapbGMS1cEEls5Ng222WH7TDh0Ef4u15KprTg==", "253039c6-ab72-48ee-8d86-3153278f1c09" });
        }
    }
}
