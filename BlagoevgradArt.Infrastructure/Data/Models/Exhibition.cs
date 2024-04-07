using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The exhibition entity class.
    /// </summary>
    public class Exhibition
    {
        /// <summary>
        /// Exhibition unique identifier.
        /// </summary>
        [Key]
        [Comment("Exhibition unique identifier. | Уникален идентификатор на изложбата.")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the exhibition.
        /// </summary>
        [Required]
        [MaxLength(ExhibitionNameMaxLength)]
        [Comment("Name of the exhibition. | Име на изложбата.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Opening date of the exhibition.
        /// </summary>
        [Required]
        [Comment("Opening date of the exhibition. | Дата на откриване на изложбата.")]
        public DateTime OpeningDate { get; set; }

        /// <summary>
        /// Description of the exhibition.
        /// </summary>
        [Required]
        [MaxLength(ExhibitionDescriptionMaxLength)]
        [Comment("Description of the exhibition. | Описание на изложбата.")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Unique identifier of the exhibition's hosting gallery.
        /// </summary>
        [Required]
        [MaxLength(GalleryIdMaxLength)]
        [Comment("Unique identifier of the gallery hosting the exhibition. | Уникален идентификатор на галерията, в която е изложбата.")]
        public string GalleryId { get; set; } = string.Empty;

        /// <summary>
        /// Navigation property to the exhibition's hosting gallery.
        /// </summary>
        [ForeignKey(nameof(GalleryId))]
        public Gallery Gallery { get; set; } = null!;

        /// <summary>
        /// Navigation property to the many-to-many entity of AuthorExhibitions.
        /// </summary>
        public List<AuthorExhibition> AuthorExhibitions { get; set; } = new List<AuthorExhibition>();
    }
}