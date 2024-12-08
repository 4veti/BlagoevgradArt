using BlagoevgradArt.Core.Models.Author;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IAuthorService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> ExistsByIdAsync(int id);
        Task<int> GetIdAsync(string userId);
        Task<AuthorProfileInfoModel?> GetAuthorProfileInfoAsync(int id);
        Task SetAuthorProfileInfoAsync(AuthorFormModel authorProfileInfo, string userId);
        Task<string> GetFullNameAsync(string userId);
        Task<List<AuthorSmallThumbnailModel>> GetAuthorThumbnailsAsync(int id, bool isAuthorAccepted);
        Task<bool> SubmitRequestToJoinExhibitionAsync(string userId, int exhibitionId);
    }
}
