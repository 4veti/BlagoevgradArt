using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class FixedSeedInconsistency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59790652-c1c9-4b65-875e-deb4b29d9fd8", "AQAAAAEAACcQAAAAEIl2KlSf5Ll2bi7Ynh9HTiaXn4PejgpJJsB1vJLy5OZfNqOcBO8x/JkhXNc6t6MqKg==", "e5ed8edf-bfc0-46b7-8326-eb54b070ce8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89876a1e-7327-4dcd-8759-89d142b79196", "AQAAAAEAACcQAAAAECk/81N942vsrrIE3DiYlYiuFFSxWZeg3w3vGa+pM68yp9cBKFK9jALwWID/OwUYUg==", "35c22205-bd90-4c75-8991-86884d1f565d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7efba940-3711-4da6-aa44-7de516561833", "AQAAAAEAACcQAAAAEE7GJCBWyQOuO/uZIr2vfxz3zOvHwFO1/hx1+1ZbAjvp0/2tnFRy8NOSZ/peNAMmwA==", "01eefc4f-fe16-4bc0-858c-592f14c64efc" });

            migrationBuilder.UpdateData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 5, 6, 15, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b77197d7-cc95-4a40-babd-50bca4286f61", "AQAAAAEAACcQAAAAECNi86wYmiI06izBl/5k2ZQjM/zeBNO6Bz9rQ3xIk3MfriosScMygK1Z3moEh7Cj1A==", "c0e332f4-bc5c-47c2-be26-dd1269e5e707" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d4e555e-e3ae-4b8d-a91c-0ea87e2a59c2", "AQAAAAEAACcQAAAAEDd9bTiXVbfHgvK+Agg0LvRQShXWvOz75/1aDDV5fsC/Q3QIr5QESiGKtRrfTSH2+A==", "77fe2ae1-40de-4a8c-a960-af50da446cae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2eeab427-8b6d-49b9-9c29-b7e2294401dd", null, "af200ab0-3131-41f5-becb-a90f9d83f0e9" });

            migrationBuilder.UpdateData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 5, 3, 15, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
