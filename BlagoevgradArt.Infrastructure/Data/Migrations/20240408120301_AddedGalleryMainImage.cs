using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlagoevgradArt.Infrastructure.Migrations
{
    public partial class AddedGalleryMainImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Galleries",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                comment: "File path to the gallery's main image. | Файлов път до главната снимка на галерията.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Galleries");
        }
    }
}
