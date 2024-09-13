using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class AddedAcceptedIndicatorForAuthorExhibitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "AuthorsExhibitions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "An indicator if the Author is accepted into the Exhibition. | Индикатор дали Авторът е приет в Изложбата.");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "AuthorsExhibitions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52c4e6b5-605e-4ab9-890e-9e8ea82c9186", "AQAAAAEAACcQAAAAEICLEw0mB+6MXCsWf6O0QYOFpTRui7wRDZSHOU2zI9sYNDAYD9mdb66SXRjN9T3hsQ==", "623386b3-a567-48c8-abc9-fc968e308222" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ab88275-24bd-41b0-b905-67281abb9cab", "AQAAAAEAACcQAAAAEHXLhFyrRcTnOscXR0oW9t3CHYRB7oAs3CA49oit7kbqVn2IF1I1dpIWIj+uDjMTFg==", "e9d61841-cd8e-424b-8ab4-56c969a98e5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feae7399-c154-462c-8160-dd891db0ef82", "AQAAAAEAACcQAAAAEEIdjGbv9MGjqNelifoEUQcGvr+amDmGdBlEWyww1xbh9TQaj18mWm51tqooM///DQ==", "6f21eda4-5425-4cac-ab77-90a4fc5d56d3" });

            migrationBuilder.UpdateData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 6, 28, 15, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
