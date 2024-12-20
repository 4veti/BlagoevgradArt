﻿using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Core.Constants.ErrorMessages;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Core.Models.Gallery;

public class GalleryFormModel
{
    [Required]
    public string UserId { get; set; } = string.Empty;
    /// <summary>
    /// Name of the gallery.
    /// </summary>
    [Required]
    [StringLength(GalleryNameMaxLength,
        MinimumLength = GalleryNameMinLength,
        ErrorMessage = InvalidLength)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Address of the gallery.
    /// </summary>
    [Required]
    [StringLength(GalleryAddressMaxLength,
        MinimumLength = GalleryAddressMinLength,
        ErrorMessage = InvalidLength)]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Working time of the gallery.
    /// </summary>
    [Required]
    [StringLength(GalleryWorkingTimeMaxLength,
        MinimumLength = GalleryWorkingTimeMinLength,
        ErrorMessage = InvalidLength)]
    public string WorkingTime { get; set; } = string.Empty;

    /// <summary>
    /// Gallery's phone number.
    /// </summary>
    [Required]
    [StringLength(PhoneNumberMaxLength,
        MinimumLength = PhoneNumberMinLength,
        ErrorMessage = InvalidLength)]
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Path to the gallery's main image.
    /// </summary>
    [StringLength(ImagePathMaxLength,
        MinimumLength = ImagePathMinLength,
        ErrorMessage = InvalidLength)]
    public string? MainImage { get; set; }

    /// <summary>
    /// Description of the gallery.
    /// </summary>
    [Required]
    [StringLength(GalleryDescriptionMaxLength,
        MinimumLength = GalleryDescriptionMinLength,
        ErrorMessage = InvalidLength)]
    public string Description { get; set; } = string.Empty;
}
