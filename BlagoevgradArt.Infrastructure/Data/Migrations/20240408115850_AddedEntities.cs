using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class AddedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ArtTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Art type's unique identifier. | Уникален идентификатор на видът изкуство.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the art type. | Име на видът изкуство.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Author unique identifier. | Уникален идентификатор на автора.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User unique identifier. | Уникален идентификатор на потребителя."),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "First name of the author. | Първото име на автора."),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Last name of the author. | Фамилия на автора."),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Author's phone number. | Телефонен номер на автора."),
                    ProfilePicturePath = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "File path to the author's profile picture. | Файлов път до профилната снимка на автора.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Base type's unique identifier. | Уникален идентификатор на основата.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Base type's name. | Име на основата.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Gallery unique identifier. | Уникален идентификатор на галерията.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User unique identifier. | Уникален идентификатор на потребителя."),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the gallery. | Име на галерията."),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Address of the gallery. | Адрес на галерията."),
                    WorkingTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Working time of the gallery. | Работно време на галерията."),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Gallery's phone number. | Телефонен номер на галерията."),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Description of the gallery. | Описание на галерията.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galleries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Genre's unique identifier. | Уникален идентификатор на жанра.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the genre. | Име на жанра.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Exhibition unique identifier. | Уникален идентификатор на изложбата.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the exhibition. | Име на изложбата."),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Opening date of the exhibition. | Дата на откриване на изложбата."),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Description of the exhibition. | Описание на изложбата."),
                    GalleryId = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the gallery hosting the exhibition. | Уникален идентификатор на галерията, в която е изложбата.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exhibitions_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsExhibitions",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false, comment: "Author's unique identifier. | Уникален идентификатор на автора."),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false, comment: "Exhibition's unique identifier. | Уникален идентификатор на изложбата.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsExhibitions", x => new { x.AuthorId, x.ExhibitionId });
                    table.ForeignKey(
                        name: "FK_AuthorsExhibitions_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorsExhibitions_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Painting's unique identifier. | Уникален идентификатор на картината.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Painting's title. | Заглавие на картината."),
                    AuthorId = table.Column<int>(type: "int", nullable: false, comment: "Author's unique identifier. | Уникален идентификатор на автора."),
                    ImagePath = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Painting's file path. | Файлов път на картината."),
                    Year = table.Column<short>(type: "smallint", nullable: true, comment: "Year of the painting. | Година на картината."),
                    GenreId = table.Column<int>(type: "int", nullable: false, comment: "Genre unique identifier. | Уникален идентификатор на жанра."),
                    ArtTypeId = table.Column<int>(type: "int", nullable: false, comment: "Art type unique identifier. | Уникален идентификатор на вида изкуство."),
                    BaseTypeId = table.Column<int>(type: "int", nullable: false, comment: "Painting's base type unique identifier. | Уникален идентификатор на основата на картината."),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "Description of the painting. | Описание на картината."),
                    HeightCm = table.Column<byte>(type: "tinyint", nullable: false, comment: "Painting's height in centimeters. | Височина на картината в сантиметри."),
                    WidthCm = table.Column<byte>(type: "tinyint", nullable: false, comment: "Painting's width in centimeters. | Широчина на картината в сантиметри."),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, comment: "Physical availability of the painting. | Физическа наличност на картината."),
                    ExhibitionId = table.Column<int>(type: "int", nullable: true, comment: "Unique identifier of the exhibition which hosts the painting. | Уникален идентификатор на изложбата, в която е картината.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paintings_ArtTypes_ArtTypeId",
                        column: x => x.ArtTypeId,
                        principalTable: "ArtTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paintings_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paintings_BaseTypes_BaseTypeId",
                        column: x => x.BaseTypeId,
                        principalTable: "BaseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paintings_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paintings_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The painting table. | Таблица за картина.");

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Material's unique identifier. | Уникален идентификатор на материала.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Name of the material. | Име на материала."),
                    PaintingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "Paintings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the technique. | Уникален идентификатор на техниката.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Technique's name. | Име на техниката."),
                    PaintingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Techniques_Paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "Paintings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PhoneNumber",
                table: "Authors",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsExhibitions_ExhibitionId",
                table: "AuthorsExhibitions",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_GalleryId",
                table: "Exhibitions",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_PhoneNumber",
                table: "Galleries",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_UserId",
                table: "Galleries",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_PaintingId",
                table: "Materials",
                column: "PaintingId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_ArtTypeId",
                table: "Paintings",
                column: "ArtTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_AuthorId",
                table: "Paintings",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_BaseTypeId",
                table: "Paintings",
                column: "BaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_ExhibitionId",
                table: "Paintings",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_GenreId",
                table: "Paintings",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Techniques_PaintingId",
                table: "Techniques",
                column: "PaintingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorsExhibitions");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "ArtTypes");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BaseTypes");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
