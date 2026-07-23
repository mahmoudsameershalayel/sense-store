using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProviderAndProductStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "ProductTbls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE ProductTbls SET Status = 5");

            migrationBuilder.CreateTable(
                name: "ProviderTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderTbls_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "789743f9-8ce4-42de-afbf-59f706d72cf6", "789743f9-8ce4-42de-afbf-59f706d72cf6", "Provider", "PROVIDER" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTbls_ProviderId",
                table: "ProductTbls",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderTbls_ApplicationUserId",
                table: "ProviderTbls",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTbls_ProviderTbls_ProviderId",
                table: "ProductTbls",
                column: "ProviderId",
                principalTable: "ProviderTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTbls_ProviderTbls_ProviderId",
                table: "ProductTbls");

            migrationBuilder.DropTable(
                name: "ProviderTbls");

            migrationBuilder.DropIndex(
                name: "IX_ProductTbls_ProviderId",
                table: "ProductTbls");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "789743f9-8ce4-42de-afbf-59f706d72cf6");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "ProductTbls");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductTbls");
        }
    }
}
