using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class FinalFixToImagePathStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "~/Images/Paintings/Vladimir_Mother.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98e0cd35-e6f4-4fb9-a72a-9cf717c7befa", "AQAAAAEAACcQAAAAEC5ln6Pqm2diGyZAJJI2wGdtRih03nm5KM3irzdRfc0SG2548/EAtdu2rOrd7tbzlg==", "acbe2ce6-c844-4bd6-904e-7fa6ff52874a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc9d63e1-110f-4288-b856-08794996118a", "AQAAAAEAACcQAAAAENhQZu9HWYmWv2Z4LlvHNXdRUhMNpACmkGBEXXAcH0/DN6QALLnKRdqX7sTp8xntaQ==", "be3d1261-bb8e-4fcc-875b-fe6f1839d14e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c20d64e3-88d1-4395-a1e9-ffd115cf4c2f", "AQAAAAEAACcQAAAAEOyFDHCgkOv+Rf5aLI/4kOcLEduRCS0vXkTVBLzum1GsvWC8MKPOp7YL/6GQMXRemw==", "7303c5c7-4cfb-4455-9f90-1b24b52a9e96" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "~/Paintings/Vladimir_Mother.jpg");
        }
    }
}
