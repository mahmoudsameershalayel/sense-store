using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addInventory1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTbls_ProductTbls_ItemId1",
                table: "InventoryTbls");

            migrationBuilder.DropIndex(
                name: "IX_InventoryTbls_ItemId1",
                table: "InventoryTbls");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "InventoryTbls");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "InventoryTbls",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bd50d62-acde-474f-ab2c-fbe777839098", "AQAAAAIAAYagAAAAEE/mDrG93fVoA4hT1J0TsfNTvHtqO4fr4Op2fzEhPPtLHgdB4eVxlku1krMvwSEHpw==", "e49a4a7b-3949-4e78-8c05-38c6a02199f8" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8382));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 55, 28, 574, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTbls_ItemId",
                table: "InventoryTbls",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTbls_ProductTbls_ItemId",
                table: "InventoryTbls",
                column: "ItemId",
                principalTable: "ProductTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTbls_ProductTbls_ItemId",
                table: "InventoryTbls");

            migrationBuilder.DropIndex(
                name: "IX_InventoryTbls_ItemId",
                table: "InventoryTbls");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "InventoryTbls",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId1",
                table: "InventoryTbls",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0efece38-ce2a-4248-8b5d-9b65ef650f0a", "AQAAAAIAAYagAAAAEHNd/J4SGE2gUDq/BkTtaFJftTFT3ZNdekUoS/rVt8XI6GaFjxqb/vv4vakRLiFiCw==", "109b69ce-fd23-416e-861c-82576d11f1c4" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6797));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 6, 15, 6, 47, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTbls_ItemId1",
                table: "InventoryTbls",
                column: "ItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTbls_ProductTbls_ItemId1",
                table: "InventoryTbls",
                column: "ItemId1",
                principalTable: "ProductTbls",
                principalColumn: "Id");
        }
    }
}
