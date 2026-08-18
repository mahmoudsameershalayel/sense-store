using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Sense.Infrastructure;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    [DbContext(typeof(SenseDbContext))]
    [Migration("20260814090000_AddProviderStorefrontSelection")]
    public partial class AddProviderStorefrontSelection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessCategoryKey",
                table: "ProviderTbls",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorefrontTemplateKey",
                table: "ProviderTbls",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessCategoryKey",
                table: "ProviderTbls");

            migrationBuilder.DropColumn(
                name: "StorefrontTemplateKey",
                table: "ProviderTbls");
        }
    }
}
