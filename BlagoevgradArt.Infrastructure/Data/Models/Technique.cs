using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The technique entity class.
    /// </summary>
    public class Technique
    {
        /// <summary>
        /// Unique identifier of the technique.
        /// </summary>
        [Key]
        [Comment("Unique identifier of the technique. | Уникален идентификатор на техниката.")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the technique.
        /// </summary>
        [Required]
        [MaxLength(TechniqueMaxLength)]
        [Comment("Technique's name. | Име на техниката.")]
        public string Name { get; set; } = string.Empty;
    }
}
