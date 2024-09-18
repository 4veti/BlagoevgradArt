using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class AddedIndicatorForPendingPaintingsToAuthorsExhibitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPendingPaintings",
                table: "AuthorsExhibitions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "An indicator if the Author has pending Paintings to be approved. | Индикатор дали Авторът има чакащи картини за одобрение.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ccdf86b-cf2c-4782-b7cf-8e02eec4a5c1", "AQAAAAEAACcQAAAAEFid9hCz2XsxWxJ8n6vi8BogQtP2XcH1nIV3DwGeGwvaCCNe71iaU/iuUEO5gNpt5w==", "37d34482-d92e-4478-8272-5cd65796efbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b626380-e12c-4f36-aa52-57585a2d7319", "AQAAAAEAACcQAAAAEApwHL4I0EV1RV6st5XCxfyMJxyahzVkZF+5TM0kJji1jAmvO63SxVXioGIsUGS/3Q==", "082a420a-669c-45e8-b4b8-eb6359156f51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86e6d731-e0cf-47d3-84bb-96cb0729a0bf", "AQAAAAEAACcQAAAAEBcUvDA13dSwupDzEnpczCmGf/0kJfedlB/Pn5iBSDQaM128mwbMfCxl0BV4L6Cptw==", "8009dab9-41e9-4d6b-a223-4fcd2ace0071" });

            migrationBuilder.UpdateData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 10, 13, 15, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPendingPaintings",
                table: "AuthorsExhibitions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "212eb8f2-fe7a-41e7-bd7d-75500977ce76", "AQAAAAEAACcQAAAAEJ+fC6+1tERTtpIsbodVBLIG419EQSBrkRYP/xcMSzE/uBE9Iu63+4j2GtpkeEGEUA==", "0cbc8c69-89ab-4011-af8c-1eac4b8ef994" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e8ef31a-4411-4bd2-ba5d-ca72c7d7e36a", "AQAAAAEAACcQAAAAEDC1UdfGJqTPwsp5cAYD/JqHGwGfUOrl4w5AXJEhp7P7UmB+0Gbj+9yFBZsJFsH8YQ==", "6fd81063-66fe-474d-971d-6f3c6a8d2d8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b33a0773-9e58-4fbd-90f3-6983cc39716e", "AQAAAAEAACcQAAAAEKkclOlYPII89lfeC1PVbRsAwklRuOD27qPg0oP1AIMI+Spn/HyXlTvSdv+9JbBhyw==", "7bb690e8-3d76-4926-ba0a-ef3844943b7c" });

            migrationBuilder.UpdateData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 10, 10, 15, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
