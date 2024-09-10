using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Exhibition;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly IRepository _repository;
        private readonly IAuthorService _authorService;

        public ExhibitionService(IRepository repository,
            IAuthorService authorService)
        {
            _repository = repository;
            _authorService = authorService;
        }

        public async Task<bool> AddAuthorToExhibitionAsync(int exhibitionId, int authorId)
        {
            bool bothExist = await _authorService.ExistsByIdAsync(authorId) &&
                await ExistsByIdAsync(exhibitionId);

            if (bothExist == false)
            {
                return false;
            }

            AuthorExhibition ae = new AuthorExhibition()
            {
                ExhibitionId = exhibitionId,
                AuthorId = authorId
            };

            await _repository.AddAsync(ae);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteExhibitionAsync(int id)
        {
            Exhibition? exhibition = await _repository
                .All<Exhibition>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (exhibition == null)
            {
                return false;
            }

            _repository.Remove(exhibition);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditExhibitionAsync(int id, ExhibitionFormModel model)
        {
            Exhibition? exhibition = await _repository
                .All<Exhibition>()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (exhibition == null)
            {
                return false;
            }

            exhibition.Name = model.Name;
            exhibition.Description = model.Description;
            exhibition.OpeningDate = model.OpeningDate;

            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            Exhibition? exhibition = await _repository.AllAsReadOnly<Exhibition>()
                .FirstOrDefaultAsync(e => e.Id == id);

            return exhibition != null;
        }

        public async Task<bool> GalleryUserIsOwnerOfExhibitionAsync(string userId, int exhibitionId)
        {
            Exhibition? exhibition = await _repository.AllAsReadOnly<Exhibition>()
                .FirstOrDefaultAsync(e => e.Gallery.UserId == userId);

            return exhibition != null;
        }

        public async Task<ExhibitionAllServiceModel> GetAllAsync(int currentPage,
            int countPerPage)
        {
            List<ExhibitionThumbnailModel> exhibitions = await _repository
                .AllAsReadOnly<Exhibition>()
                .Select(e => new ExhibitionThumbnailModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    OpeningDate = e.OpeningDate,
                    HostGalleryName = e.Gallery.Name,
                    CountArtworks = e.Paintings.Count
                })
                .ToListAsync();

            ExhibitionAllServiceModel model = new ExhibitionAllServiceModel()
            {
                TotalExhibitions = exhibitions.Count,
                Thumbnails = exhibitions.Skip((currentPage - 1) * countPerPage).Take(countPerPage).ToList()
            };

            return model;
        }

        public async Task<ExhibitionFormModel?> GetFormDataByIdAsync(int id)
        {
            Exhibition? exhibition = await _repository
                .AllAsReadOnly<Exhibition>()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            return exhibition == null ? null : new ExhibitionFormModel()
            {
                Name = exhibition.Name,
                Description = exhibition.Description,
                OpeningDate = exhibition.OpeningDate
            };
        }

        public async Task<ExhibitionDetailsModel?> GetInfoAsync(int id)
        {
            Exhibition? exhibition = await _repository
                .AllAsReadOnly<Exhibition>()
                .Include(e => e.AuthorExhibitions)
                    .ThenInclude(ae => ae.Author)
                .Include(e => e.Gallery)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (exhibition == null)
            {
                return null;
            }

            ExhibitionDetailsModel infoModel = new ExhibitionDetailsModel()
            {
                Id = id,
                Name = exhibition.Name,
                OpeningDate = exhibition.OpeningDate,
                Description = exhibition.Description,
                HostGalleryName = exhibition.Gallery.Name,
                Participants = await _authorService.GetAuthorThumbnails(id, isAuthorInExhibition: true)
            };

            return infoModel;
        }

        public async Task<bool> RemoveAuthorFromExhibitionAsync(int exhibitionId, int authorId)
        {
            AuthorExhibition? authorExhibition = await _repository
                .AllAsReadOnly<AuthorExhibition>()
                .Where(ae => ae.ExhibitionId == exhibitionId && ae.AuthorId == authorId)
                .FirstOrDefaultAsync();

            if (authorExhibition == null)
            {
                return false;
            }

            _repository.Remove(authorExhibition);

            List<Painting> paintingsInExhibition = await _repository
                .All<Painting>()
                .Where(p => p.ExhibitionId == exhibitionId && p.AuthorId == authorId)
                .ToListAsync();
            paintingsInExhibition.ForEach(p => p.ExhibitionId = null);

            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<int> SaveExhibitionAsync(int galleryId, ExhibitionFormModel model)
        {
            Exhibition exhibition = new Exhibition
            {
                Name = model.Name,
                OpeningDate = model.OpeningDate,
                Description = model.Description,
                GalleryId = galleryId
            };

            await _repository.AddAsync(exhibition);
            await _repository.SaveChangesAsync();

            return exhibition.Id;
        }
    }
}
