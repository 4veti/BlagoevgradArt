using BlagoevgradArt.Core.Models.Author;
using BlagoevgradArt.Core.Models.Exhibition;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IExhibitionService
    {
        Task<bool> ExistsByIdAsync(int id);

        Task<ExhibitionDetailsModel> GetInfoAsync(int id);

        Task<int> SaveExhibitionAsync(int galleryId, ExhibitionFormModel model);

        Task EditExhibitionAsync(int id, ExhibitionFormModel model);

        Task<ExhibitionFormModel> GetFormDataByIdAsync(int id);

        Task<ExhibitionAllServiceModel> GetAllAsync(int currentPage,
            int countPerPage);

        Task<bool> DeleteExhibitionAsync(int id);

        Task<List<AuthorSmallThumbnailModel>> GetAuthorThumbnails(int id);

        Task<bool> GalleryUserIsOwnerOfExhibition(string userId, int exhibitionId);

        Task AddAuthorToExhibitionAsync(int exhibitionId, int authorId);
    }
}
