using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderInvoiceLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                table: "InvoiceTbls");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceRecordId",
                table: "InvoiceTbls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "InvoiceTbls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTbls_OrderId",
                table: "InvoiceTbls",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                table: "InvoiceTbls",
                column: "MaintenanceRecordId",
                principalTable: "MaintenanceRecordTbls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbls_OrderTbls_OrderId",
                table: "InvoiceTbls",
                column: "OrderId",
                principalTable: "OrderTbls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                table: "InvoiceTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbls_OrderTbls_OrderId",
                table: "InvoiceTbls");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceTbls_OrderId",
                table: "InvoiceTbls");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "InvoiceTbls");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceRecordId",
                table: "InvoiceTbls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbls_MaintenanceRecordTbls_MaintenanceRecordId",
                table: "InvoiceTbls",
                column: "MaintenanceRecordId",
                principalTable: "MaintenanceRecordTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
