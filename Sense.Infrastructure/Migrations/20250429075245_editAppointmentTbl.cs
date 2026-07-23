using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editAppointmentTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_SparePartId",
                table: "InvoiceTbl");

            migrationBuilder.DropColumn(
                name: "CustomerCity",
                table: "AppointmentTbls");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "AppointmentTbls");

            migrationBuilder.RenameColumn(
                name: "SparePartId",
                table: "InvoiceTbl",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "PartCost",
                table: "InvoiceTbl",
                newName: "ProductCost");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceTbl_SparePartId",
                table: "InvoiceTbl",
                newName: "IX_InvoiceTbl_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "ProductTbls",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "CartItemTbls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductOfferDisVal",
                table: "CartItemTbls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductNetPrice",
                table: "CartItemTbls",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "ProductAmount",
                table: "CartItemTbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleModel",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleBrand",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AppointmentDetails",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "744b7e56-a950-4657-82c1-ab8975f3dac9", "AQAAAAIAAYagAAAAEE76lv4/XeZ547eZF473TZScWgNdMgXnJMnxS/q3EGwAVQiwjBPQ+QO0NMgZu4mwOQ==", "ad592f76-95b4-43b7-a886-34a4411079c7" });

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_ProductId",
                table: "InvoiceTbl",
                column: "ProductId",
                principalTable: "ProductTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_ProductId",
                table: "InvoiceTbl");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "ProductTbls");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "InvoiceTbl",
                newName: "SparePartId");

            migrationBuilder.RenameColumn(
                name: "ProductCost",
                table: "InvoiceTbl",
                newName: "PartCost");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceTbl_ProductId",
                table: "InvoiceTbl",
                newName: "IX_InvoiceTbl_SparePartId");

            migrationBuilder.AlterColumn<double>(
                name: "ProductPrice",
                table: "CartItemTbls",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ProductOfferDisVal",
                table: "CartItemTbls",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ProductNetPrice",
                table: "CartItemTbls",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ProductAmount",
                table: "CartItemTbls",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VehicleModel",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleBrand",
                table: "AppointmentTbls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppointmentDetails",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerCity",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "AppointmentTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d19e6bb8-78b8-4f78-b3bf-9aa69044a682", "AQAAAAIAAYagAAAAENtbSuJyxGBkGfrg68Uv1NgGbPSruM8tlasbVFIJveXtTXx7wuR2g1YgC/IARL8XYQ==", "bdbfaf14-7093-4a40-90c4-814240ba8f54" });

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTbl_ProductTbls_SparePartId",
                table: "InvoiceTbl",
                column: "SparePartId",
                principalTable: "ProductTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
