using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IRepository _repository;
        private readonly IExhibitionService _exhibitionService;

        public GalleryService(IRepository repository,
            IExhibitionService exhibitionService)
        {
            _repository = repository;
            _exhibitionService = exhibitionService;
        }

        public async Task<int> ApproveOrDisapprovePaintingAsync(int id, string galleryUserId, bool approved)
        {
            Painting? painting = await _repository
                .All<Painting>()
                .Include(p => p.Author)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            int exhibitionId = painting?.ExhibitionId ?? -1;

            if (painting == null || exhibitionId < 1)
            {
                throw new NullReferenceException();
            }

            bool isPaintingInGalleryOwnedExhibition = await _exhibitionService
                .GalleryUserIsOwnerOfExhibitionAsync(galleryUserId, exhibitionId);

            if (isPaintingInGalleryOwnedExhibition == false)
            {
                throw new UnauthorizedAccessException();
            }

            if (approved == false)
            {
                painting.ExhibitionId = null;
            }

            int countRequestedPaintings = await _repository
                .AllAsReadOnly<Painting>()
                .Where(p => p.AuthorId == painting.AuthorId &&
                    p.ExhibitionId == exhibitionId &&
                    p.IsAccepted == false)
                .CountAsync();

            painting.IsAccepted = approved;

            if (countRequestedPaintings == 1)
            {
                AuthorExhibition authorExhibition = await _repository
                    .All<AuthorExhibition>()
                    .FirstAsync(ae => ae.AuthorId == painting.AuthorId && ae.ExhibitionId == exhibitionId);

                authorExhibition.HasPendingPaintings = false;
            }

            await _repository.SaveChangesAsync();

            return exhibitionId;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            Gallery? gallery = await _repository.AllAsReadOnly<Gallery>().FirstOrDefaultAsync(g => g.UserId == userId);

            if (gallery == null)
            {
                return false;
            }

            return true;
        }

        public async Task<int> GetIdAsync(string userId)
        {
            Gallery? gallery = await _repository
                .AllAsReadOnly<Gallery>()
                .FirstOrDefaultAsync(g => g.UserId == userId);

            return gallery?.Id ?? -1;
        }
    }
}
