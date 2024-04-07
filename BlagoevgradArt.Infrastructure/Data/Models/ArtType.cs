using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The art type entity class.
    /// </summary>
    public class ArtType
    {
        /// <summary>
        /// Art type's unique identifier.
        /// </summary>
        [Key]
        [Comment("Art type's unique identifier. | Уникален идентификатор на видът изкуство.")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the art type.
        /// </summary>
        [Required]
        [MaxLength(ArtTypeNameMaxLength)]
        [Comment("Name of the art type. | Име на видът изкуство.")]
        public string Name { get; set; } = string.Empty;
    }
}