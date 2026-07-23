using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6c3171f-250c-48cd-a0a0-e30127ccc01d", "AQAAAAIAAYagAAAAEDWLwG47tGqBVPQgaXY8OetvAZGu27RVHdZ48mWjv5/pEb+1NQOCrog4h7pHxo+CWg==", "5927d306-a216-438c-860b-1cb132c5606d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe1f8a55-2756-4a33-bab7-1f58d9200900", "AQAAAAIAAYagAAAAEJyAIVH1xL4CZOr17Ac45FW4Wkq4aKYsyOuYxp2HHBuaWV1PlCAAxSa12oU56Dtp0Q==", "f41c175a-13ce-4444-bf88-83739a45c605" });
        }
    }
}
