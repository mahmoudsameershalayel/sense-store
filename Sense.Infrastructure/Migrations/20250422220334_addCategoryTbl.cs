using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTbls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisorTbl_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionTbl_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentTbls_BranchTbls_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BranchTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentTbls_CustomerTbls_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityAvaliable = table.Column<int>(type: "int", nullable: false),
                    IsSparePart = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTbl_CategoryTbls_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecordTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecordTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecordTbl_AppointmentTbls_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "AppointmentTbls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecordTbl_SupervisorTbl_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "SupervisorTbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PartCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LaborCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaintenanceRecordId = table.Column<int>(type: "int", nullable: false),
                    SparePartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceTbl_MaintenanceRecordTbl_MaintenanceRecordId",
                        column: x => x.MaintenanceRecordId,
                        principalTable: "MaintenanceRecordTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceTbl_ProductTbl_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "ProductTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f242e4ec-054a-4cbc-be64-b9728f926795", "AQAAAAIAAYagAAAAEGLcIDgAqVgrLj0ZFzHwbkMowT8X21SJP0LVLxdHKvfDFvg9ajRhYVoaxTB2VdO7fw==", "e9d13554-e2d7-46ed-924d-29b4bf63b7c6" });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTbls_BranchId",
                table: "AppointmentTbls",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTbls_CustomerId",
                table: "AppointmentTbls",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTbl_MaintenanceRecordId",
                table: "InvoiceTbl",
                column: "MaintenanceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTbl_SparePartId",
                table: "InvoiceTbl",
                column: "SparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecordTbl_AppointmentId",
                table: "MaintenanceRecordTbl",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecordTbl_SupervisorId",
                table: "MaintenanceRecordTbl",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTbl_CategoryId",
                table: "ProductTbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorTbl_ApplicationUserId",
                table: "SupervisorTbl",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTbl_CustomerId",
                table: "TransactionTbl",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceTbl");

            migrationBuilder.DropTable(
                name: "TransactionTbl");

            migrationBuilder.DropTable(
                name: "MaintenanceRecordTbl");

            migrationBuilder.DropTable(
                name: "ProductTbl");

            migrationBuilder.DropTable(
                name: "AppointmentTbls");

            migrationBuilder.DropTable(
                name: "SupervisorTbl");

            migrationBuilder.DropTable(
                name: "CategoryTbls");

            migrationBuilder.DropTable(
                name: "BranchTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6c3171f-250c-48cd-a0a0-e30127ccc01d", "AQAAAAIAAYagAAAAEDWLwG47tGqBVPQgaXY8OetvAZGu27RVHdZ48mWjv5/pEb+1NQOCrog4h7pHxo+CWg==", "5927d306-a216-438c-860b-1cb132c5606d" });
        }
    }
}
