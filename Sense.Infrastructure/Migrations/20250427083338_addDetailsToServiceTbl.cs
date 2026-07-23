using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addDetailsToServiceTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetilsAr",
                table: "ServiceTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c387c4d9-19ea-4f2f-b2bb-a37ceda06771", "AQAAAAIAAYagAAAAEKbThfblJs859N0EOPLQJh7g5QvMI17qG5iP3z75N7pDgzDk48rz4RUYsf6hEkdkCA==", "54307052-de53-4223-aa2a-49a901993762" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetilsAr",
                table: "ServiceTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eec2c6f-0f4a-4e5f-855f-689b14157696", "AQAAAAIAAYagAAAAECV0eXk9xBR8G+jqZYvsig5VuwuPLKslSyAo0bKzakQzj5nq2Rk84mdnvODnS1xxsw==", "b8f94b51-ce85-48f5-92ca-dafc539b9871" });
        }
    }
}
