using BlagoevgradArt.Core.Models.Exhibition;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IExhibitionService
    {
        Task<bool> ExistsByIdAsync(int id);

        Task<ExhibitionDetailsModel?> GetInfoAsync(int id);

        Task<int> SaveExhibitionAsync(int galleryId, ExhibitionFormModel model);

        Task EditExhibitionAsync(int id, ExhibitionFormModel model);

        Task<ExhibitionFormModel> GetFormDataByIdAsync(int id);

        Task<ExhibitionAllServiceModel> GetAllAsync(int currentPage,
            int countPerPage);

        Task<bool> DeleteExhibitionAsync(int id);
    }
}
