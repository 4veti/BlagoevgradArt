using BlagoevgradArt.Core.Models.Exhibition;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IExhibitionService
    {
        public Task<ExhibitionDetailsModel?> GetInfoAsync(int id);

        public Task<int> SaveExhibitionAsync(int galleryId, ExhibitionFormModel model);

        public Task<int> GetIdAsync(string userId);

        public Task<bool> ExistsByIdAsync(string userId);
    }
}
