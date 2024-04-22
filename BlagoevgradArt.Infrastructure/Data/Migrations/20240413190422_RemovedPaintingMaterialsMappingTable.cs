using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class RemovedPaintingMaterialsMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Paintings_PaintingId",
                table: "Materials");

            migrationBuilder.DropTable(
                name: "PaintingMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Materials_PaintingId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "PaintingId",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Paintings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Painting's material unique identifier. | Уникален идентификатор на материала на картината.");

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
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaterialId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaterialId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaterialId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_MaterialId",
                table: "Paintings",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Materials_MaterialId",
                table: "Paintings",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Materials_MaterialId",
                table: "Paintings");

            migrationBuilder.DropIndex(
                name: "IX_Paintings_MaterialId",
                table: "Paintings");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Paintings");

            migrationBuilder.AddColumn<int>(
                name: "PaintingId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaintingMaterial",
                columns: table => new
                {
                    PaintingId = table.Column<int>(type: "int", nullable: false, comment: "Painting unique identifier. | Уникален идентификатор на картината."),
                    MaterialId = table.Column<int>(type: "int", nullable: false, comment: "Material unique identifier. | Уникален идентификатор на материала.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingMaterial", x => new { x.PaintingId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_PaintingMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaintingMaterial_Paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "Paintings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "PaintingMaterial",
                columns: new[] { "MaterialId", "PaintingId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_PaintingId",
                table: "Materials",
                column: "PaintingId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingMaterial_MaterialId",
                table: "PaintingMaterial",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Paintings_PaintingId",
                table: "Materials",
                column: "PaintingId",
                principalTable: "Paintings",
                principalColumn: "Id");
        }
    }
}
