using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class AddedPaintingsCollectionToAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d11551d-9876-423d-bc43-a732c4ebcdc4", "AQAAAAEAACcQAAAAECWAbmLF5vTpeVeCE9Z/dr0ORemCPceJ2l2vatQjirKiyxVbg5mk2cgrFkW1eetu0g==", "803c7e56-05be-4c79-b778-09f41b5f8ee7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "813a7187-e494-4a0a-a1d0-ce7a4c94efb3", "AQAAAAEAACcQAAAAEP7I6Z77DdpafTjb9HsX1QcuMQ5uB92E2P+KNUzk/seR8Fian0LS8l3z+R5PSsZtsQ==", "02baaa30-8b7b-43d6-809d-fa92009fff3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc121b7f-0c7f-43d0-b12a-57ba621b0229", "AQAAAAEAACcQAAAAEBBo0FY8GqFkr9KtHH44jVWuXZemFobXDVI20UUHb0dHoNUY4RFTlGONHk83UFberA==", "acbf3d0f-7987-4ae1-be19-4b1a62bcf949" });

            migrationBuilder.UpdateData(
                table: "Exhibitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2024, 5, 8, 15, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
