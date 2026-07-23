using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_ProductId",
                table: "InvoiceTbl");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "InvoiceTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CanceledReason",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuildingNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FloorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlatNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FamousSign = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LocationLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationLat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForMe = table.Column<bool>(type: "bit", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressTbls_CustomerTbls_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderEznNo = table.Column<long>(type: "bigint", nullable: true),
                    OrderEznNetValue = table.Column<double>(type: "float", nullable: true),
                    OrderEznMemo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTipVal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsHaveSaleInv = table.Column<bool>(type: "bit", nullable: true),
                    SaleInvNo = table.Column<long>(type: "bigint", nullable: true),
                    IsUpload = table.Column<bool>(type: "bit", nullable: true),
                    UploadUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadLoginNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDateTtime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: true),
                    OrderEznDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutForDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTbls_AddressTbls_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressTbls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailsTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ser = table.Column<long>(type: "bigint", nullable: false),
                    EznNo = table.Column<long>(type: "bigint", nullable: true),
                    EznSer = table.Column<long>(type: "bigint", nullable: false),
                    EznDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EznTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerDatabaseKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EznItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EznItemPrice = table.Column<double>(type: "float", nullable: true),
                    EznItemAmount = table.Column<double>(type: "float", nullable: true),
                    EznItemOfferDisValue = table.Column<double>(type: "float", nullable: true),
                    EznItemNetPrice = table.Column<double>(type: "float", nullable: true),
                    EznMemo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHaveSaleInv = table.Column<bool>(type: "bit", nullable: true),
                    SaleInvNo = table.Column<long>(type: "bigint", nullable: true),
                    IsUpload = table.Column<bool>(type: "bit", nullable: true),
                    UploadUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadLoginNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDateTtime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanShipItem = table.Column<bool>(type: "bit", nullable: false),
                    CauseMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailsTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetailsTbls_OrderTbls_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailsTbls_ProductTbls_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d0d1d9e-fb95-4796-90e3-e7d689c85c30", "AQAAAAIAAYagAAAAEOjxxbL4W/4h3l4aELkK8ZpTkxJLbf8ifT8gAlODwreHNYaW9s7fS4HIsUJRS9tVhQ==", "3919003e-4c9d-4339-8057-f7aeeebc8bfb" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1663));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 13, 52, 10, 606, DateTimeKind.Utc).AddTicks(1668));

            migrationBuilder.CreateIndex(
                name: "IX_AddressTbls_CustomerId1",
                table: "AddressTbls",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsTbls_CustomerId",
                table: "OrderDetailsTbls",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsTbls_OrderId",
                table: "OrderDetailsTbls",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsTbls_ProductId",
                table: "OrderDetailsTbls",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTbls_AddressId",
                table: "OrderTbls",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTbls_CustomerId",
                table: "OrderTbls",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_ProductId",
                table: "InvoiceTbl",
                column: "ProductId",
                principalTable: "ProductTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_ProductId",
                table: "InvoiceTbl");

            migrationBuilder.DropTable(
                name: "OrderDetailsTbls");

            migrationBuilder.DropTable(
                name: "OrderTbls");

            migrationBuilder.DropTable(
                name: "AddressTbls");

            migrationBuilder.DropColumn(
                name: "CanceledReason",
                table: "AppointmentTbls");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "InvoiceTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "701f2dd1-2f95-47e7-8e06-fb4fc1e8b569", "AQAAAAIAAYagAAAAEA1auJPiyF5aSa/vn51FISzDfV8kPGIhIkBFb292GY9PnliwoqAkrFUNsCisYu0LMg==", "baeab7a3-627b-4303-9ce8-4855bb654397" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 8, 16, 505, DateTimeKind.Utc).AddTicks(4589));

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_ProductId",
                table: "InvoiceTbl",
                column: "ProductId",
                principalTable: "ProductTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
