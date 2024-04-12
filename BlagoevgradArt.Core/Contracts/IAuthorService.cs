namespace BlagoevgradArt.Core.Contracts
{
    public interface IAuthorService
    {
        Task<bool> ExistsByIdAsync(string userId);
    }
}
