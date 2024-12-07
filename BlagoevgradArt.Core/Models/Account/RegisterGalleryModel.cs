using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Core.Constants.ErrorMessages;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Core.Models.Account;

public class RegisterGalleryModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100,
        MinimumLength = 6,
        ErrorMessage = InvalidLength)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required]
    [StringLength(GalleryNameMaxLength,
            MinimumLength = GalleryNameMinLength,
            ErrorMessage = InvalidLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(GalleryAddressMaxLength,
        MinimumLength = GalleryAddressMinLength,
        ErrorMessage = InvalidLength)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [StringLength(GalleryWorkingTimeMaxLength,
        MinimumLength = GalleryWorkingTimeMinLength,
        ErrorMessage = InvalidLength)]
    public string WorkingTime { get; set; } = string.Empty;

    [Required]
    [StringLength(PhoneNumberMaxLength,
        MinimumLength = PhoneNumberMinLength,
        ErrorMessage = InvalidLength)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(GalleryDescriptionMaxLength,
        MinimumLength = GalleryDescriptionMinLength,
        ErrorMessage = InvalidLength)]
    public string Description { get; set; } = string.Empty;
}
