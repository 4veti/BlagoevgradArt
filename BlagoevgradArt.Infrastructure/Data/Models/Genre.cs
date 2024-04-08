using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The genre entity class.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Genre unique identifier.
        /// </summary>
        [Key]
        [Comment("Genre's unique identifier. | Уникален идентификатор на жанра.")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the genre.
        /// </summary>
        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("Name of the genre. | Име на жанра.")]
        public string Name { get; set; } = string.Empty;
    }
}