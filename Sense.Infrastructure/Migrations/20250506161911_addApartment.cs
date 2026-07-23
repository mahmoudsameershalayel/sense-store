using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addApartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTbl_CustomerTbls_CustomerId",
                table: "TransactionTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTbl",
                table: "TransactionTbl");

            migrationBuilder.RenameTable(
                name: "TransactionTbl",
                newName: "TransactionTbls");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionTbl_CustomerId",
                table: "TransactionTbls",
                newName: "IX_TransactionTbls_CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "Apartment",
                table: "AddressTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "TransactionTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "TransactionTbls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTbls",
                table: "TransactionTbls",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CouponTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponTbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71032fe0-eafd-4a02-9cf1-8c0f92076b51", "AQAAAAIAAYagAAAAEB27vJhYjITcww+DmURoU097JWMijAvjaYp9zISy+6PzevUZ0XeD0/pE7DhNRDLiXw==", "eb097601-86b0-403e-87af-09cdc5ab0fe5" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1705));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1708));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 6, 16, 19, 8, 841, DateTimeKind.Utc).AddTicks(1724));

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTbls_WalletId",
                table: "TransactionTbls",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTbls_CustomerId",
                table: "WalletTbls",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionTbls_CustomerTbls_CustomerId",
                table: "TransactionTbls",
                column: "CustomerId",
                principalTable: "CustomerTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionTbls_WalletTbls_WalletId",
                table: "TransactionTbls",
                column: "WalletId",
                principalTable: "WalletTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTbls_CustomerTbls_CustomerId",
                table: "TransactionTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTbls_WalletTbls_WalletId",
                table: "TransactionTbls");

            migrationBuilder.DropTable(
                name: "CouponTbls");

            migrationBuilder.DropTable(
                name: "WalletTbls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionTbls",
                table: "TransactionTbls");

            migrationBuilder.DropIndex(
                name: "IX_TransactionTbls_WalletId",
                table: "TransactionTbls");

            migrationBuilder.DropColumn(
                name: "Apartment",
                table: "AddressTbls");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "TransactionTbls");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "TransactionTbls");

            migrationBuilder.RenameTable(
                name: "TransactionTbls",
                newName: "TransactionTbl");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionTbls_CustomerId",
                table: "TransactionTbl",
                newName: "IX_TransactionTbl_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionTbl",
                table: "TransactionTbl",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ede36ff-4c6b-4baa-a055-4c2097503aa6", "AQAAAAIAAYagAAAAENpJgEDbxH2MnHOtE8M+JWGGdnPuQTA36h9edLYyK0fXtH2ne3sGtrA6vyv8qYmKig==", "476412b0-8d37-453e-985a-803f56043b5b" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 5, 22, 10, 42, 927, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionTbl_CustomerTbls_CustomerId",
                table: "TransactionTbl",
                column: "CustomerId",
                principalTable: "CustomerTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
