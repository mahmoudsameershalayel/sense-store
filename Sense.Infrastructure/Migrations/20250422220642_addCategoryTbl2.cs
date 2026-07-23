using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryTbl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "CategoryTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a91aa12-01b9-429f-af67-851667a0a7e0", "AQAAAAIAAYagAAAAEHiUi2KKSeJq8yj/RFF1OVFuVuYI2s9mosc7iIn9QzWPQdzGH/ScQ/OSxE1gY0kl4A==", "dca82cdf-8ccb-46ab-8196-6a6a6ca9d4d1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "CategoryTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f242e4ec-054a-4cbc-be64-b9728f926795", "AQAAAAIAAYagAAAAEGLcIDgAqVgrLj0ZFzHwbkMowT8X21SJP0LVLxdHKvfDFvg9ajRhYVoaxTB2VdO7fw==", "e9d13554-e2d7-46ed-924d-29b4bf63b7c6" });
        }
    }
}
