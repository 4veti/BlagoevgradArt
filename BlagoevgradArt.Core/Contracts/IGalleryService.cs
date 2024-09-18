namespace BlagoevgradArt.Core.Contracts
{
    public interface IGalleryService
    {
        public Task<bool> ExistsByIdAsync(string userId);

        public Task<int> GetIdAsync(string userId);

        public Task<int> ApproveOrDisapprovePaintingAsync(int id, string galleryUserId, bool approved);
    }
}
