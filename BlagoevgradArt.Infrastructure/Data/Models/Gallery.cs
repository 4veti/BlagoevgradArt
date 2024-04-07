using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The gallery entity class. It inherits IdentityUser class.
    /// </summary>
    public class Gallery : IdentityUser
    {
        [Required]
        [MaxLength(GalleryNameMaxLength)]
        [Comment("Name of the gallery. | Име на галерията.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Address of the gallery.
        /// </summary>
        [Required]
        [MaxLength(GalleryAddressMaxLength)]
        [Comment("Address of the gallery. | Адрес на галерията.")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Working time of the gallery.
        /// </summary>
        [Required]
        [MaxLength(GalleryWorkingTimeMaxLength)]
        [Comment("Working time of the gallery. | Работно време на галерията.")]
        public string WorkingTime { get; set; } = string.Empty;

        /// <summary>
        /// Description of the gallery.
        /// </summary>
        [Required]
        [MaxLength(GalleryDescriptionMaxLength)]
        [Comment("Description of the gallery. | Описание на галерията.")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// List of exhibitions in the gallery.
        /// </summary>
        public List<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
    }
}
