using BlagoevgradArt.Core.Models.Painting;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IPaintingService
    {
        Task<int> AddPaintingAsync(PaintingFormModel model, int authorId, string imagePath);

        Task<PaintingDetailsModel?> GetPaintingDetailsAsync(int id);

        Task EditPaintingAsync(PaintingFormModel model, int id);

        Task<PaintingFormModel> GetPaintingFormModel(int id);

        Task<PaintingQueryServiceModel> AllAsync(int currentPage, int housesPerPage);
    }
}
