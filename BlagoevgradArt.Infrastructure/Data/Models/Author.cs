using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The author entity class. It inherits the IdentityUser class.
    /// </summary>
    public class Author : IdentityUser
    {
        /// <summary>
        /// First name of the author.
        /// </summary>
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("First name of the author. | Първото име на автора.")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Lase name of the author.
        /// </summary>
        [MaxLength(LastNameMaxLength)]
        [Comment("Last name of the author. | Фамилия на автора.")]
        public string? LastName { get; set; }

        /// <summary>
        /// Path to the author's profile picture.
        /// </summary>
        [MaxLength(ImagePathMaxLength)]
        [Comment("File path to the author's profile picture. | Файлов път до профилната снимка на автора.")]
        public string? ProfilePicturePath { get; set; }

        /// <summary>
        /// Navigation property to the many-to-many table of AuthorExhibitions.
        /// </summary>
        public List<AuthorExhibition> AuthorExhibitions { get; set; } = new List<AuthorExhibition>();
    }
}