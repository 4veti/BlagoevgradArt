using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The author entity class.
    /// </summary>
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Author
    {
        /// <summary>
        /// Author unique identifier.
        /// </summary>
        [Key]
        [Comment("Author unique identifier. | Уникален идентификатор на автора.")]
        public int Id { get; set; }

        /// <summary>
        /// User unique identifier.
        /// </summary>
        [Required]
        [Comment("User unique identifier. | Уникален идентификатор на потребителя.")]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Navigation property to the helper IdentityUser class.
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public AuthorHelperUser User { get; set; } = null!;

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
        /// Author's phone number.
        /// </summary>
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Author's phone number. | Телефонен номер на автора.")]
        public string PhoneNumber { get; set; } = string.Empty;

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