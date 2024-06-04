using BlagoevgradArt.Core.Models.Author;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IAuthorService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<int> GetIdAsync(string userId);
        Task<AuthorProfileInfoModel> GetAuthorProfileInfo(string userId);
        Task SetAuthorProfileInfo(AuthorFormModel authorProfileInfo, string userId);
    }
}
