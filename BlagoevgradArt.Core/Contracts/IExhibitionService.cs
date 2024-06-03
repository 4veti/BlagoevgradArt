using BlagoevgradArt.Core.Models.Exhibition;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IExhibitionService
    {
        public Task<ExhibitionDetailsModel?> GetInfoAsync(int id);

        public Task<int> SaveExhibitionAsync(int galleryId, ExhibitionFormModel model);

        public Task EditExhibitionAsync(int id, ExhibitionFormModel model);

        public Task<ExhibitionFormModel> GetFormDataByIdAsync(int id);

        public Task<ExhibitionAllServiceModel> GetAllAsync(int currentPage,
            int countPerPage);
    }
}
