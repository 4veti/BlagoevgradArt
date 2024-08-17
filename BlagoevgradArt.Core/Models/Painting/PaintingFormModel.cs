using BlagoevgradArt.Core.Contracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Core.Constants.ErrorMessages;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Core.Models.Painting;

/// <summary>
/// ViewModel DTO for the Image form data.
/// </summary>
public class PaintingFormModel : IPaintingInformationModel
{
    /// <summary>
    /// Empty constructor is left in case it's needed.
    /// </summary>
    public PaintingFormModel()
    {

    }

    /// <summary>
    /// Helper constructor for easier initialization.
    /// </summary>
    /// <param name="genres">Available genres of the painting.</param>
    /// <param name="artTypes">Available art types of the painting.</param>
    /// <param name="baseTypes">Available base types of the painting.</param>
    /// <param name="materials">Available materials of the painting.</param>
    public PaintingFormModel(IEnumerable<GenreViewModel> genres,
        IEnumerable<ArtTypeViewModel> artTypes,
        IEnumerable<BaseTypeViewModel> baseTypes,
        IEnumerable<MaterialViewModel> materials)
    {
        Genres = genres;
        ArtTypes = artTypes;
        BaseTypes = baseTypes;
        Materials = materials;
    }

    /// <summary>
    /// Title of the painting.
    /// </summary>
    [Required]
    [StringLength(TitleMaxLength,
        MinimumLength = TitleMinLength,
        ErrorMessage = InvalidLength)]
    [Display(Name = "Заглавие")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Unique identifier of the painting's author.
    /// </summary>
    [Required]
    public int AuthorId { get; set; }

    /// <summary>
    /// Author name for url slug generation.
    /// </summary>
    public string AuthorName { get; set; } = string.Empty;

    /// <summary>
    /// Year of finishing the painting.
    /// </summary>
    [Display(Name = "Година")]
    public int? Year { get; set; }

    /// <summary>
    /// Unique identifier of the painting's genre.
    /// </summary>
    [Required]
    [Display(Name = "Жанр")]
    public int GenreId { get; set; }

    /// <summary>
    /// Lst of available genres.
    /// </summary>
    public IEnumerable<GenreViewModel> Genres = new List<GenreViewModel>();

    /// <summary>
    /// Unique identifier of the painting's art type.
    /// </summary>
    [Required]
    [Display(Name = "Вид изкуство")]
    public int ArtTypeId { get; set; }

    /// <summary>
    /// List of available art types.
    /// </summary>
    public IEnumerable<ArtTypeViewModel> ArtTypes = new List<ArtTypeViewModel>();

    /// <summary>
    /// Unique identifier of the painting's base type.
    /// </summary>
    [Required]
    [Display(Name = "Основа")]
    public int BaseTypeId { get; set; }

    /// <summary>
    /// List of all available base types.
    /// </summary>
    public IEnumerable<BaseTypeViewModel> BaseTypes = new List<BaseTypeViewModel>();

    /// <summary>
    /// Material unique identifier.
    /// </summary>
    [Display(Name = "Материал")]
    public int MaterialId { get; set; }

    /// <summary>
    /// List of available materials.
    /// </summary>
    public IEnumerable<MaterialViewModel> Materials { get; set; } = new List<MaterialViewModel>();

    /// <summary>
    /// Description of the painting.
    /// </summary>
    [StringLength(ImageDescriptionMaxLength,
        MinimumLength = ImageDescriptionMinLength,
        ErrorMessage = InvalidLength)]
    [Display(Name = "Описание")]
    public string? Description { get; set; }

    /// <summary>
    /// Height of the painting in centimeters.
    /// </summary>
    [Required]
    [Range(HeightCmMinValue,
        HeightCmMaxValue,
        ErrorMessage = DimensionsInvalidValue)]
    [Display(Name = "Височина в см")]
    public int HeightCm { get; set; }

    /// <summary>
    /// Width of the painting in centimeters;
    /// </summary>
    [Required]
    [Range(WidthCmMinValue,
        WidthCmMaxValue,
        ErrorMessage = DimensionsInvalidValue)]
    [Display(Name = "Широчина в см")]
    public int WidthCm { get; set; }

    /// <summary>
    /// Physical availability of the painting.
    /// </summary>
    [Required]
    [Display(Name = "Наличност")]
    public bool IsAvailable { get; set; }

    /// <summary>
    /// File of the painting.
    /// </summary>
    [Required]
    [Display(Name = "Файл на картината")]
    public IFormFile ImageFile { get; set; } = null!;
}
