using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The painting entity class.
    /// </summary>
    [Comment("The painting table. | Таблица за картина.")]
    public class Painting
    {
        /// <summary>
        /// Painting's unique identifier.
        /// </summary>
        [Key]
        [Comment("Painting's unique identifier. | Уникален идентификатор на картината.")]
        public int Id { get; set; }

        /// <summary>
        /// Title of the painting.
        /// </summary>
        [Required]
        [MinLength(TitleMaxLength)]
        [Comment("Painting's title. | Заглавие на картината.")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Unique identifier of the painting's author.
        /// </summary>
        [Required]
        [MaxLength(AuthorIdMaxLength)]
        [Comment("Author's unique identifier. | Уникален идентификатор на автора.")]
        public string AuthorId { get; set; } = string.Empty;

        /// <summary>
        /// Author of the painting.
        /// </summary>
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!;

        /// <summary>
        /// File path to the image.
        /// </summary>
        [Required]
        [MaxLength(ImagePathMaxLength)]
        [Comment("Painting's file path. | Файлов път на картината.")]
        public string ImagePath { get; set; } = string.Empty;

        /// <summary>
        /// Year of finishing the painting.
        /// </summary>
        [Column(TypeName = "smallint")]
        [Comment("Year of the painting. | Година на картината.")]
        public int? Year { get; set; }

        /// <summary>
        /// Unique identifier of the painting's genre.
        /// </summary>
        [Required]
        [Comment("Genre unique identifier. | Уникален идентификатор на жанра.")]
        public int GenreId { get; set; }

        /// <summary>
        /// Genre of the painting.
        /// </summary>
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        /// <summary>
        /// Unique identifier of the painting's art type.
        /// </summary>
        [Required]
        [Comment("Art type unique identifier. | Уникален идентификатор на вида изкуство.")]
        public int ArtTypeId { get; set; }

        /// <summary>
        /// Painting's art type.
        /// </summary>
        [ForeignKey(nameof(ArtTypeId))]
        public ArtType ArtType { get; set; } = null!;

        /// <summary>
        /// Unique identifier of the painting's base type.
        /// </summary>
        [Required]
        [Comment("Painting's base type unique identifier. | Уникален идентификатор на основата на картината.")]
        public int BaseTypeId { get; set; }

        /// <summary>
        /// Base type of the Painting.
        /// </summary>
        [ForeignKey(nameof(BaseTypeId))]
        public BaseType BaseType { get; set; } = null!;

        /// <summary>
        /// List of materials used in the painting.
        /// </summary>
        public List<Material> Materials { get; set; } = new List<Material>();

        /// <summary>
        /// Height of the painting in centimeters.
        /// </summary>
        [Required]
        [Column(TypeName = "tinyint")]
        [Comment("Painting's height in centimeters. | Височина на картината в сантиметри.")]
        public int HeightCm { get; set; }

        /// <summary>
        /// Width of the painting in centimeters;
        /// </summary>
        [Required]
        [Column(TypeName = "tinyint")]
        [Comment("Painting's width in centimetres. | Широчина на картината в сантиметри.")]
        public int WidthCm { get; set; }

        /// <summary>
        /// Physical availability of the painting.
        /// </summary>
        [Required]
        [Comment("Physical availability of the painting. | Физическа наличност на картината.")]
        public bool IsAvailable { get; set; }

        [Comment("Unique identifier of the exhibition which hosts the painting. | Уникален идентификатор на изложбата, в която е картината.")]
        public int? ExhibitionParticipationId { get; set; }

        /// <summary>
        /// Current participation in an exhibition.
        /// </summary>
        [ForeignKey(nameof(ExhibitionParticipationId))]
        public Exhibition? ExhibitionParticipation { get; set; }
    }
}
