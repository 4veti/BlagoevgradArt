using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class ChangedImagesPathString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 6, 28, 15, 0, 0, 0, DateTimeKind.Local));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78dfbf7b-1025-4920-b0ca-f767a0cea2e9", "AQAAAAEAACcQAAAAECb7v3AddwwxfGkBm5iCqyVQeZ3Gx0nOsXFv3G3JTsvKXnB5mReEnZv2I6CyDmV31w==", "b5dd5238-23b0-49ad-9cfa-5d4027d8cfb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77237eb6-1474-4c7e-88b5-d60c282484a0", "AQAAAAEAACcQAAAAENiaV3gcSxn87g2nvrp//lRB3CsXdMgRBdpnK/EwFKl61lGazLPn/U4bBXn8fWKt+A==", "f64eefcb-d1b9-4bd7-8b7d-202dd3875269" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8300171c-e334-481f-896e-29bc1be1bc97", "AQAAAAEAACcQAAAAEOlOme4gszBoXxncFpI9azeyVYR87HeDw7RM3AKN7yg/J/EdFqsG5gKtdbOIrjR7yg==", "62800cdc-1b89-4c44-bf07-19a300b884ac" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfilePicturePath",
                value: "BlagoevgradArt\\Images\\Authors\\Tsanko_Lavrenov.jpg");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProfilePicturePath",
                value: "BlagoevgradArt\\Images\\Authors\\Tsanko_Lavrenov.jpg");

            migrationBuilder.UpdateData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 5, 8, 15, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "BlagoevgradArt\\Images\\Paintings\\Vladimir_Woman.jpg");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "BlagoevgradArt\\Images\\Paintings\\Vladimir_Mother.jpg");

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "BlagoevgradArt\\Images\\Paintings\\Tsanko_Hilendarski.jpg");
        }
    }
}
