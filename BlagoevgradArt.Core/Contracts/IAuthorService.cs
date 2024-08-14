using BlagoevgradArt.Core.Models.Author;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IAuthorService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> ExistsByIdAsync(int id);
        Task<int> GetIdAsync(string userId);
        Task<AuthorProfileInfoModel> GetAuthorProfileInfo(int id);
        Task SetAuthorProfileInfo(AuthorFormModel authorProfileInfo, string userId);
    }
}
