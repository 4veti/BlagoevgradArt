using BlagoevgradArt.Core.Models.Exhibition;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IExhibitionService
    {
        Task<bool> ExistsByIdAsync(int id);
        Task<ExhibitionDetailsModel?> GetInfoAsync(int id);
        Task<int> SaveExhibitionAsync(int galleryId, ExhibitionFormModel model);
        Task<bool> EditExhibitionAsync(int id, ExhibitionFormModel model);
        Task<ExhibitionFormModel?> GetFormDataByIdAsync(int id);
        Task<ExhibitionAllServiceModel> GetAllAsync(int currentPage, int countPerPage);
        Task<bool> DeleteExhibitionAsync(int id);
        Task<bool> GalleryUserIsOwnerOfExhibitionAsync(string userId, int exhibitionId);
        Task<bool> AddAuthorToExhibitionAsync(int exhibitionId, int authorId);
        Task<bool> RemoveAuthorFromExhibitionAsync(int exhibitionId, int authorId);
        Task<bool> IsAuthorPartOfExhibitionAsync(string userId, int exhibitionId);
        Task<bool> IsAuthorRequestedToJoinExhibitionAsync(string userId, int exhibitionId);
        Task<bool> SubmitPaintingsRequestAsync(List<int> paintings, int exhibitionId);
        Task<int> GetCountAcceptedPaintingsForAuthorAsync(int authorId, int exhibitionId);
    }
}
