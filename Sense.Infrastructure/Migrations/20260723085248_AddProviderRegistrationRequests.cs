using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProviderRegistrationRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProviderRequestTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BusinessDescription = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    DocumentStoredName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentOriginalName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DocumentContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentFileSize = table.Column<long>(type: "bigint", nullable: false),
                    AcceptedTerms = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InternalNote = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedByUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ApprovedProviderId = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderRequestTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderRequestTbls_ProviderTbls_ApprovedProviderId",
                        column: x => x.ApprovedProviderId,
                        principalTable: "ProviderTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProviderRequestTbls_ApprovedProviderId",
                table: "ProviderRequestTbls",
                column: "ApprovedProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderRequestTbls_Email",
                table: "ProviderRequestTbls",
                column: "Email",
                unique: true,
                filter: "[Status] = 1 AND [IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderRequestTbls");
        }
    }
}
