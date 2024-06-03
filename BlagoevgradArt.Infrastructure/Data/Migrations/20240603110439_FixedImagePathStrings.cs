using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class FixedImagePathStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfilePicturePath",
                value: "~/Images/Authors/Tsanko_Lavrenov.jpg");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePicturePath",
                value: "~/Images/Authors/Tsanko_Lavrenov.jpg");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "~/Images/Paintings/Vladimir_Woman.jpg");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "~/Paintings/Vladimir_Mother.jpg");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "~/Images/Paintings/Tsanko_Hilendarski.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66fce671-2b43-41c1-8f55-0fdd3442cd13", "AQAAAAEAACcQAAAAELphcpLiTrD/bvnnk43IXQzQ5WOgKAZ+I/olXotA5/ryviOGugxjdvMcCc+bTvMYpQ==", "7493fe7d-f2e7-4fde-99b7-6eb5c5056293" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bb04b26-3a13-46c1-a412-d5b22b7657d0", "AQAAAAEAACcQAAAAEHpR1puZPHo/36YjIbpGgVQnM8iFeGXlxCALkycQzyXwfFN5nzTo3YDW30RyhbWNPw==", "c5a1a6cf-a89b-4ca3-b79c-c78f81b9270b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db6de1ba-c348-471b-a29f-283b201cc643", "AQAAAAEAACcQAAAAEFPiACWOUNCxgIi8dzyd+tFxNABzB1/Gbavxu2L/XbKcwXoRW/Mn8SL4NmqNNA5PZQ==", "7635b3b5-36b5-496a-a99e-b40dc7d786be" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfilePicturePath",
                value: "~/BlagoevgradArt/Images/Authors/Tsanko_Lavrenov.jpg");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePicturePath",
                value: "~/BlagoevgradArt/Images/Authors/Tsanko_Lavrenov.jpg");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "~/BlagoevgradArt/Images/Paintings/Vladimir_Woman.jpg");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "~/BlagoevgradArt/Paintings/Vladimir_Mother.jpg");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "~/BlagoevgradArt/Images/Paintings/Tsanko_Hilendarski.jpg");
        }
    }
}
