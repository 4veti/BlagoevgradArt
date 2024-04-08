using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsExhibitions_Exhibitions_ExhibitionId",
                table: "AuthorsExhibitions");

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

            migrationBuilder.InsertData(
                table: "ArtTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Живопис" },
                    { 2, "Графика" },
                    { 3, "Рисунка" },
                    { 4, "Дърворезба" },
                    { 5, "Керамика" },
                    { 6, "Витраж" },
                    { 7, "Металопластика" },
                    { 8, "Декоративна скулптора" },
                    { 9, "Бижутерия" },
                    { 10, "Оригами" },
                    { 12, "Друго" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b6e897e-6594-4453-ade4-305d69ae8391", 0, "91380cc1-0db9-4714-894d-198143251aae", "AuthorHelperUser", "tsankolavrenov@mail.com", false, false, null, "tsankolavrenov@mail.com", "tsankolavrenov@mail.com", "AQAAAAEAACcQAAAAEAiaJ9avksootfA7cIHs6czLhcZtPI5KDPXnQ/zTxufgHRW5jNMy/iyOP2jFHWvPhg==", null, false, "606d2258-45df-4918-bb5f-7f7e965d8e15", false, "tsankolavrenov@mail.com" },
                    { "7d7a4b74-dd27-4262-b932-ee5cd63a519d", 0, "52330b0d-5290-4450-a452-71d76cf71aea", "AuthorHelperUser", "vladimaistora@mail.com", false, false, null, "vladimaistora@mail.com", "vladimaistora@mail.com", "AQAAAAEAACcQAAAAEF4E75R8kht7UOsNG/4x9fKjw3R6JhDHo8QP/70ySYi/+y1116Y/Xam/PTggyXnmIg==", null, false, "49975b45-2dd6-4442-bc1a-254b4f3ed5ba", false, "vladimaistora@mail.com" },
                    { "a9d96207-30f8-40cb-a670-adc6acd76fba", 0, "b3708e47-789e-4153-b49a-b4ade5781c2b", "GalleryHelperUser", "gallery@mail.com", false, false, null, "gallery@mail.com", "gallery@mail.com", null, null, false, "edd41f67-8c44-4f97-879e-433f46bbc52b", false, "gallery@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "BaseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Платно" },
                    { 2, "Хартия" },
                    { 3, "Стъкло" },
                    { 4, "Дърво" },
                    { 5, "Картон" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Портрет" },
                    { 2, "Пейзаж" },
                    { 3, "Натюрморт" },
                    { 4, "Фигурална композиция" },
                    { 5, "Абстракция" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Name", "PaintingId" },
                values: new object[,]
                {
                    { 1, "Акварел", null },
                    { 2, "Темпера", null },
                    { 3, "Маслени бои", null },
                    { 4, "Сух пастел", null },
                    { 5, "Маслен пастел", null },
                    { 6, "Молив", null },
                    { 7, "Мастило", null },
                    { 8, "Дърво", null },
                    { 9, "Колаж", null }
                });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "Name", "PaintingId" },
                values: new object[,]
                {
                    { 1, "Висок печат", null },
                    { 2, "Дълбок печат", null },
                    { 3, "Плосък печат (литография)", null },
                    { 4, "Сериграфия (ситопечат)", null },
                    { 5, "Дигитални техники", null }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber", "ProfilePicturePath", "UserId" },
                values: new object[] { 1, "Vladimir", "Maistora", "+359888654321", "BlagoevgradArt\\Images\\Authors\\Tsanko_Lavrenov.jpg", "7d7a4b74-dd27-4262-b932-ee5cd63a519d" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber", "ProfilePicturePath", "UserId" },
                values: new object[] { 2, "Tsanko", "Lavrenov", "+359888654321", "BlagoevgradArt\\Images\\Authors\\Tsanko_Lavrenov.jpg", "1b6e897e-6594-4453-ade4-305d69ae8391" });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Address", "Description", "MainImage", "Name", "PhoneNumber", "UserId", "WorkingTime" },
                values: new object[] { 1, "ул. \"Горно нанадолнище\" №0, кв. \"Кал до колене\", Благоевград.", "Най-дейната и известна галерия в югозапада.", null, "АртГалерия", "+359888696969", "a9d96207-30f8-40cb-a670-adc6acd76fba", "Пон-Пет 08:30-19:30" });

            migrationBuilder.InsertData(
                table: "AuthorsExhibitions",
                columns: new[] { "AuthorId", "ExhibitionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Paintings",
                columns: new[] { "Id", "ArtTypeId", "AuthorId", "BaseTypeId", "Description", "ExhibitionId", "GenreId", "HeightCm", "ImagePath", "IsAvailable", "Title", "WidthCm", "Year" },
                values: new object[,]
                {
                    { 1, 3, 1, 1, "Тази картина вероятно е от XXв.", null, 1, (byte)69, "BlagoevgradArt\\Images\\Paintings\\Vladimir_Woman.jpg", false, "Жена", (byte)42, (short)1920 },
                    { 2, 3, 1, 2, "Тази картина изобразява неизвестна жена от миналия век.", null, 1, (byte)50, "BlagoevgradArt\\Images\\Paintings\\Vladimir_Mother.jpg", false, "Майка", (byte)30, (short)1923 },
                    { 3, 1, 2, 1, "Пейзаж на Хилендарския манастир.", null, 2, (byte)55, "BlagoevgradArt\\Images\\Paintings\\Tsanko_Hilendarski.jpg", false, "Хилендарския манастир", (byte)73, (short)1945 }
                });

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
                name: "IX_PaintingMaterial_MaterialId",
                table: "PaintingMaterial",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsExhibitions_Exhibitions_ExhibitionId",
                table: "AuthorsExhibitions",
                column: "ExhibitionId",
                principalTable: "Exhibitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorsExhibitions_Exhibitions_ExhibitionId",
                table: "AuthorsExhibitions");

            migrationBuilder.DropTable(
                name: "PaintingMaterial");

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AuthorsExhibitions",
                keyColumns: new[] { "AuthorId", "ExhibitionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorsExhibitions",
                keyColumns: new[] { "AuthorId", "ExhibitionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BaseTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BaseTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BaseTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Techniques",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9d96207-30f8-40cb-a670-adc6acd76fba");

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArtTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BaseTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BaseTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b6e897e-6594-4453-ade4-305d69ae8391");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d7a4b74-dd27-4262-b932-ee5cd63a519d");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorsExhibitions_Exhibitions_ExhibitionId",
                table: "AuthorsExhibitions",
                column: "ExhibitionId",
                principalTable: "Exhibitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
