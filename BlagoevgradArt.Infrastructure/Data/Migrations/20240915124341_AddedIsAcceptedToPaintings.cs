using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class AddedIsAcceptedToPaintings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Paintings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indicator if the Painting is accepted in an Exhibition. | Индикатор дали картината е приета в изложба.");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Paintings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d304449c-f4d4-4925-a320-6a382fbe99b4", "AQAAAAEAACcQAAAAECtgzMdkQrs4fTMie8i+4dEIooimtdNWRNnaj3q6V3f9hCy980ExNlzp6FiQm1REqw==", "e6f98a11-cf0b-4931-b31e-c82c1b0a3136" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87ae2dbb-083c-4e2c-834d-6c45f219b2ea", "AQAAAAEAACcQAAAAEAbFnlKC+qjyIGg5YirQrwDdxpl00vFXeHtcijGsT+jBLaLV0Rwyn9r+m0CiIPE3Uw==", "eeeea0c9-a5e9-482f-b272-6a312547ae87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63413f3b-4f0f-45d2-a154-072d9c4e27fe", "AQAAAAEAACcQAAAAEIrKTLTPGImDWJ/Ii8KvWo8Krx3xc+6iMgMPBgqX6qxwCudziypneHsLYU5eFvFRYg==", "6ec67b3a-ec7a-4815-a5f0-e2584dcf013d" });

            migrationBuilder.UpdateData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 10, 8, 15, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
