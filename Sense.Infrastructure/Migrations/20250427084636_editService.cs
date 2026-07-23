using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetilsAr",
                table: "ServiceTbls",
                newName: "DetailsAr");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "951d9f2a-a753-4902-b4cb-1cc678e597d4", "AQAAAAIAAYagAAAAEHxkh6nOVL7ricwN72hFS8oUCc/STpapbGMS1cEEls5Ng222WH7TDh0Ef4u15KprTg==", "253039c6-ab72-48ee-8d86-3153278f1c09" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetailsAr",
                table: "ServiceTbls",
                newName: "DetilsAr");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c387c4d9-19ea-4f2f-b2bb-a37ceda06771", "AQAAAAIAAYagAAAAEKbThfblJs859N0EOPLQJh7g5QvMI17qG5iP3z75N7pDgzDk48rz4RUYsf6hEkdkCA==", "54307052-de53-4223-aa2a-49a901993762" });
        }
    }
}
