using BlagoevgradArt.Core.Models.Painting;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IGalleryService
    {
        public Task<bool> ExistsByIdAsync(string userId);

        public Task<int> GetIdAsync(string userId);
    }
}
