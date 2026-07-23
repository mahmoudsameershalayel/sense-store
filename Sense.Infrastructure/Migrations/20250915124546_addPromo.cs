using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPromo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketingCampaignTbls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CampaignUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingCampaignTbls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketingCampaignTbls_ProductTbls_ProductId",
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
                values: new object[] { "e5a87790-d0a1-491f-9141-1656aff805fb", "AQAAAAIAAYagAAAAEHGvgqA674TxtQ+9RWMsQr/X6+CFTr7YBfCdPV3zf+aEGH9xrrOfGi0cbXxoPWlQ2Q==", "cc97c01e-0654-4ef3-88a5-1adf6669a974" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1253));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 15, 12, 45, 43, 559, DateTimeKind.Utc).AddTicks(1256));

            migrationBuilder.CreateIndex(
                name: "IX_MarketingCampaignTbls_ProductId",
                table: "MarketingCampaignTbls",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketingCampaignTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3318edd2-5c12-44eb-94f9-3e433bfd1c53", "AQAAAAIAAYagAAAAEAwWtt9zFuoAcYTP9WMS8pHNxgg6n0EiLPQq2YFbwkKuVQ0EVyYC03tpZB4tRSll+Q==", "5c16ad3a-88d8-404a-a32d-c2aedf3e7480" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "ModelTbls",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 13, 9, 2, 26, 766, DateTimeKind.Utc).AddTicks(250));
        }
    }
}
