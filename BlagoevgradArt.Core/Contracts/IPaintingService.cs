using BlagoevgradArt.Core.Models.Painting;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IPaintingService
    {
        Task<int> AddPaintingAsync(PaintingFormModel model, int authorId);
    }
}
