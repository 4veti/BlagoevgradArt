using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services
{
    public class PaintingService : IPaintingService
    {
        private readonly IRepository _repository;
        private readonly IPaintingHelperService _paintingHelperService;

        public PaintingService(IRepository repository,
            IPaintingHelperService paintingHelperService)
        {
            _repository = repository;
            _paintingHelperService = paintingHelperService;
        }

        public async Task<int> AddPaintingAsync(PaintingFormModel model, int authorId, string imagePath)
        {
            Painting painting = new Painting()
            {
                Title = model.Title,
                AuthorId = authorId,
                ImagePath = imagePath,
                Year = model.Year,
                GenreId = model.GenreId,
                ArtTypeId = model.ArtTypeId,
                BaseTypeId = model.BaseTypeId,
                MaterialId = model.MaterialId,
                Description = model.Description,
                HeightCm = model.HeightCm,
                WidthCm = model.WidthCm,
                IsAvailable = model.IsAvailable
            };

            await _repository.AddAsync(painting);
            await _repository.SaveChangesAsync();

            return painting.Id;
        }

        public async Task EditPaintingAsync(PaintingFormModel model, int id, string rootPath)
        {
            Painting? painting = await _repository
                .GetByIdAsync<Painting>(id);

            if (painting != null)
            {
                painting.Title = model.Title;
                painting.Year = model.Year;
                painting.GenreId = model.GenreId;
                painting.ArtTypeId = model.ArtTypeId;
                painting.BaseTypeId = model.BaseTypeId;
                painting.MaterialId = model.MaterialId;
                painting.Description = model.Description;
                painting.HeightCm = model.HeightCm;
                painting.WidthCm = model.WidthCm;
                painting.IsAvailable = model.IsAvailable;

                if (model.ImageFile != null)
                {
                    DeleteImageByPath(painting.ImagePath, rootPath);

                    string newFilePath = $"{rootPath}\\Images\\Paintings\\{model.ImageFile.FileName}";

                    using (FileStream stream = File.Create(newFilePath))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }

                    painting.ImagePath = $"~/Images/Paintings/{model.ImageFile.FileName}";
                }

                await _repository.SaveChangesAsync();
            }
        }

        public async Task<PaintingQueryServiceModel> AllAsync(int currentPage, 
            int countPerPage,
            string? authorFirstName,
            string? artType)
        {
            var paintingsToShow = _repository
                .AllAsReadOnly<Painting>();

            if (authorFirstName != null)
            {
                string normalizedAuthorFirstName = authorFirstName.ToLower();
                paintingsToShow = paintingsToShow
                    .Where(p => p.Author.FirstName.ToLower().Contains(normalizedAuthorFirstName));
            }

            if (artType != null)
            {
                string normalizedArtType = artType.ToLower();
                paintingsToShow = paintingsToShow
                    .Where(p => p.ArtType.Name.ToLower().Contains(normalizedArtType));
            }

            IEnumerable<PaintingThumbnailModel> thumbnailsToShow = await paintingsToShow
                .Select(p => new PaintingThumbnailModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Height = p.HeightCm,
                    Width = p.WidthCm,
                    AuthorName = (p.Author.FirstName + " " + p.Author.LastName ?? "").Trim(),
                    ImagePath = p.ImagePath
                })
                .Skip((currentPage - 1) * countPerPage)
                .Take(countPerPage)
                .ToListAsync();

            return new PaintingQueryServiceModel()
            {
                Thumbnails = thumbnailsToShow,
                TotalThumbnailsCount = thumbnailsToShow.Count()
            };
        }

        public async Task<PaintingDetailsModel?> GetPaintingDetailsAsync(int id)
        {
            PaintingDetailsModel? model = await _repository
                .AllAsReadOnly<Painting>()
                .Where(p => p.Id == id)
                .Select(p => new PaintingDetailsModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    AuthorName = string.Join(" ", new string[] { p.Author.FirstName, p.Author.LastName ?? string.Empty }),
                    Year = p.Year,
                    Genre = p.Genre.Name,
                    ArtType = p.ArtType.Name,
                    BaseType = p.BaseType.Name,
                    Material = p.Material.Name,
                    Description = p.Description,
                    HeightCm = p.HeightCm,
                    WidthCm = p.WidthCm,
                    IsAvailable = p.IsAvailable,
                    ImagePath = p.ImagePath
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<PaintingFormModel> GetPaintingFormModel(int id)
        {
            Painting painting = await _repository
                .AllAsReadOnly<Painting>()
                .FirstAsync(p => p.Id == id);


            return new PaintingFormModel()
            {
                Title = painting.Title,
                AuthorId = painting.AuthorId,
                Year = painting.Year,
                GenreId = painting.GenreId,
                Genres = await _paintingHelperService.GetGenresAsync(),
                ArtTypeId = painting.ArtTypeId,
                ArtTypes = await _paintingHelperService.GetArtTypesAsync(),
                BaseTypeId = painting.BaseTypeId,
                BaseTypes = await _paintingHelperService.GetBaseTypesAsync(),
                MaterialId = painting.MaterialId,
                Materials = await _paintingHelperService.GetMaterialsAsync(),
                Description = painting.Description,
                HeightCm = painting.HeightCm,
                WidthCm = painting.WidthCm,
                IsAvailable = painting.IsAvailable
            };
        }

        public async Task DeleteImageAsync(int id, string rootPath)
        {
            Painting? painting = await _repository.GetByIdAsync<Painting>(id);
            
            if (painting != null)
            {
                DeleteImageByPath(painting.ImagePath, rootPath);

                _repository.Remove(painting);
                await _repository.SaveChangesAsync();
            }
        }        

        private void DeleteImageByPath(string imagePath, string rootPath)
        {
            string filePath = $"{rootPath}{imagePath.Trim('~').Replace("/", "\\")}";
            File.Delete(filePath);
        }
    }
}
