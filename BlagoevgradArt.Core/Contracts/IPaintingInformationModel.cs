
namespace BlagoevgradArt.Core.Contracts;

public interface IPaintingInformationModel
{
    string AuthorName { get; set; }

    string Title { get; set; }

    string? Description { get; set; }

    int HeightCm { get; set; }

    int WidthCm { get; set; }
}
