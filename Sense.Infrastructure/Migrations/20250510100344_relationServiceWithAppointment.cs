using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sense.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationServiceWithAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "AppointmentTbls",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c2a32c9-57fe-4dc2-a839-914fb88c96f6", "AQAAAAIAAYagAAAAEAH8a7Px7cVfGSixtXYZhPeZu4Dm23BZt0OZBtr2Wy66foOGWClcUMTUP1TfA0uT+g==", "607e37ab-41a3-4028-ac1d-3024bd6021fe" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 10, 10, 3, 41, 440, DateTimeKind.Utc).AddTicks(9169));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTbls_ServiceId",
                table: "AppointmentTbls",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTbls_ServiceTbls_ServiceId",
                table: "AppointmentTbls",
                column: "ServiceId",
                principalTable: "ServiceTbls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTbls_ServiceTbls_ServiceId",
                table: "AppointmentTbls");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentTbls_ServiceId",
                table: "AppointmentTbls");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "AppointmentTbls");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0-9412-4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36b9cf56-2145-47c2-85c2-2b45f8276bf0", "AQAAAAIAAYagAAAAEG2eJdIURo6nuOzkceIJFVEKTa83N1YD68+J2NC7/9EdHWDwCplSLe8P2WLTABKcrg==", "8de6d3d5-f385-4823-b071-bcccc690e94f" });

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "BrandTbls",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 7, 10, 28, 58, 169, DateTimeKind.Utc).AddTicks(4567));
        }
    }
}
