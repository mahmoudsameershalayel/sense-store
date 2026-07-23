using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbl_MaintenanceRecordTbl_MaintenanceRecordId",
                table: "InvoiceTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_ProductId",
                table: "InvoiceTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecordTbl_AppointmentTbls_AppointmentId",
                table: "MaintenanceRecordTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecordTbl_SupervisorTbl_SupervisorId",
                table: "MaintenanceRecordTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceRecordTbl",
                table: "MaintenanceRecordTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceTbl",
                table: "InvoiceTbl");

            migrationBuilder.DropColumn(
                name: "CanShipItem",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "CauseMessage",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "EznItemAmount",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "EznItemCode",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "EznItemNetPrice",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "EznItemOfferDisValue",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "EznItemPrice",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "EznNo",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "EznSer",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "Ser",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "AddressTbls");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AddressTbls");

            migrationBuilder.DropColumn(
                name: "IsForMe",
                table: "AddressTbls");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AddressTbls");

            migrationBuilder.RenameTable(
                name: "MaintenanceRecordTbl",
                newName: "MaintenanceRecordTbls");

            migrationBuilder.RenameTable(
                name: "InvoiceTbl",
                newName: "InvoiceTbls");

            migrationBuilder.RenameColumn(
                name: "EznMemo",
                table: "OrderDetailsTbls",
                newName: "Memo");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AddressTbls",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceRecordTbl_SupervisorId",
                table: "MaintenanceRecordTbls",
                newName: "IX_MaintenanceRecordTbls_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceRecordTbl_AppointmentId",
                table: "MaintenanceRecordTbls",
                newName: "IX_MaintenanceRecordTbls_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceTbl_ProductId",
                table: "InvoiceTbls",
                newName: "IX_InvoiceTbls_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceTbl_MaintenanceRecordId",
                table: "InvoiceTbls",
                newName: "IX_InvoiceTbls_MaintenanceRecordId");

            migrationBuilder.AddColumn<decimal>(
                name: "OfferDisVal",
                table: "ProductTbls",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxPrcent",
                table: "ProductTbls",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VatPrcent",
                table: "ProductTbls",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductAmount",
                table: "OrderDetailsTbls",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductNetPrice",
                table: "OrderDetailsTbls",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductOfferDisValue",
                table: "OrderDetailsTbls",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "OrderDetailsTbls",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceRecordTbls",
                table: "MaintenanceRecordTbls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceTbls",
                table: "InvoiceTbls",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "483dedb0-7d81-4e61-8a6e-0327766ed4ff", "AQAAAAIAAYagAAAAEEYMEQfRb/l48KIR02DvUU35VqjPXwtqfs/6HMb1pRXNKu7+XI/uXQ+uT9bCy3yBOA==", "90468071-0ba6-4c3e-b67d-381249d2b4d3" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 18, 12, 54, 702, DateTimeKind.Utc).AddTicks(3069));

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                table: "InvoiceTbls",
                column: "MaintenanceRecordId",
                principalTable: "MaintenanceRecordTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbls_ProductTbls_ProductId",
                table: "InvoiceTbls",
                column: "ProductId",
                principalTable: "ProductTbls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecordTbls_AppointmentTbls_AppointmentId",
                table: "MaintenanceRecordTbls",
                column: "AppointmentId",
                principalTable: "AppointmentTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecordTbls_SupervisorTbl_SupervisorId",
                table: "MaintenanceRecordTbls",
                column: "SupervisorId",
                principalTable: "SupervisorTbl",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                table: "InvoiceTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbls_ProductTbls_ProductId",
                table: "InvoiceTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecordTbls_AppointmentTbls_AppointmentId",
                table: "MaintenanceRecordTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRecordTbls_SupervisorTbl_SupervisorId",
                table: "MaintenanceRecordTbls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceRecordTbls",
                table: "MaintenanceRecordTbls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceTbls",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "OfferDisVal",
                table: "ProductTbls");

            migrationBuilder.DropColumn(
                name: "TaxPrcent",
                table: "ProductTbls");

            migrationBuilder.DropColumn(
                name: "VatPrcent",
                table: "ProductTbls");

            migrationBuilder.DropColumn(
                name: "ProductAmount",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "ProductNetPrice",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "ProductOfferDisValue",
                table: "OrderDetailsTbls");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "OrderDetailsTbls");

            migrationBuilder.RenameTable(
                name: "MaintenanceRecordTbls",
                newName: "MaintenanceRecordTbl");

            migrationBuilder.RenameTable(
                name: "InvoiceTbls",
                newName: "InvoiceTbl");

            migrationBuilder.RenameColumn(
                name: "Memo",
                table: "OrderDetailsTbls",
                newName: "EznMemo");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "AddressTbls",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceRecordTbls_SupervisorId",
                table: "MaintenanceRecordTbl",
                newName: "IX_MaintenanceRecordTbl_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceRecordTbls_AppointmentId",
                table: "MaintenanceRecordTbl",
                newName: "IX_MaintenanceRecordTbl_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceTbls_ProductId",
                table: "InvoiceTbl",
                newName: "IX_InvoiceTbl_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceTbls_MaintenanceRecordId",
                table: "InvoiceTbl",
                newName: "IX_InvoiceTbl_MaintenanceRecordId");

            migrationBuilder.AddColumn<bool>(
                name: "CanShipItem",
                table: "OrderDetailsTbls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CauseMessage",
                table: "OrderDetailsTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EznItemAmount",
                table: "OrderDetailsTbls",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EznItemCode",
                table: "OrderDetailsTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EznItemNetPrice",
                table: "OrderDetailsTbls",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EznItemOfferDisValue",
                table: "OrderDetailsTbls",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EznItemPrice",
                table: "OrderDetailsTbls",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EznNo",
                table: "OrderDetailsTbls",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EznSer",
                table: "OrderDetailsTbls",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Ser",
                table: "OrderDetailsTbls",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "AddressType",
                table: "AddressTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AddressTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForMe",
                table: "AddressTbls",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AddressTbls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceRecordTbl",
                table: "MaintenanceRecordTbl",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceTbl",
                table: "InvoiceTbl",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d5e2550-961b-4e23-aa26-fc70a835cd76", "AQAAAAIAAYagAAAAEB8KMVu9Ar22+xnLyCg+rIqmXPFaOZGLS45CxvIbUyy2sqhgcLbv6iqVgwWf5cueUQ==", "3d02dfdb-4a96-47c9-a15c-23c8b58c7cba" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 7, 37, 8, 693, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbl_MaintenanceRecordTbl_MaintenanceRecordId",
                table: "InvoiceTbl",
                column: "MaintenanceRecordId",
                principalTable: "MaintenanceRecordTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_ProductId",
                table: "InvoiceTbl",
                column: "ProductId",
                principalTable: "ProductTbls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecordTbl_AppointmentTbls_AppointmentId",
                table: "MaintenanceRecordTbl",
                column: "AppointmentId",
                principalTable: "AppointmentTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRecordTbl_SupervisorTbl_SupervisorId",
                table: "MaintenanceRecordTbl",
                column: "SupervisorId",
                principalTable: "SupervisorTbl",
                principalColumn: "Id");
        }
    }
}
