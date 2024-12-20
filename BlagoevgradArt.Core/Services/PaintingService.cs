﻿using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Exceptions;
using BlagoevgradArt.Core.Extensions;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services
{
    public class PaintingService : IPaintingService
    {
        private readonly IRepository _repository;
        private readonly IPaintingHelperService _paintingHelperService;
        private readonly IAuthorService _authorService;

        public PaintingService(IRepository repository,
            IPaintingHelperService paintingHelperService,
            IAuthorService authorService)
        {
            _repository = repository;
            _paintingHelperService = paintingHelperService;
            _authorService = authorService;
        }

        public async Task<int> AddPaintingAsync(PaintingFormModel model, string userId, string rootPath)
        {
            await SaveImageToDiskAsync(model.ImageFile, model.ImageFile.FileName, rootPath);

            int authorId = await _authorService.GetIdAsync(userId);

            Painting painting = new Painting()
            {
                Title = model.Title,
                AuthorId = authorId,
                ImagePath = $"~/Images/Paintings/{model.ImageFile.FileName}",
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

            if (painting == null)
            {
                return;
            }

            painting.Title = model.Title;
            painting.Year = model.Year;
            painting.GenreId = model.GenreId;
            painting.ImagePath = $"~/Images/Paintings/{model.ImageFile.FileName}";
            painting.ArtTypeId = model.ArtTypeId;
            painting.BaseTypeId = model.BaseTypeId;
            painting.MaterialId = model.MaterialId;
            painting.Description = model.Description;
            painting.HeightCm = model.HeightCm;
            painting.WidthCm = model.WidthCm;
            painting.IsAvailable = model.IsAvailable;

            DeleteImageByPath(painting.ImagePath, rootPath);
            await SaveImageToDiskAsync(model.ImageFile, model.ImageFile.FileName, rootPath);

            await _repository.SaveChangesAsync();
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
                    Description = p.Description == null ? null : p.Description.Substring(0, 100),
                    HeightCm = p.HeightCm,
                    WidthCm = p.WidthCm,
                    AuthorName = (p.Author.FirstName + " " + p.Author.LastName ?? "").Trim(),
                    ImagePath = p.ImagePath
                })
                .Skip((currentPage - 1) * countPerPage)
                .Take(countPerPage)
                .ToListAsync();

            return new PaintingQueryServiceModel()
            {
                Thumbnails = thumbnailsToShow,
                TotalThumbnailsCount = await paintingsToShow.CountAsync()
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
                    ExhibitionId = p.ExhibitionId,
                    ExhibitionName = p.Exhibition == null ? null : p.Exhibition.Name,
                    ImagePath = p.ImagePath
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<PaintingFormModel?> GetPaintingFormModelAsync(int id)
        {
            Painting? painting = await _repository
                .AllAsReadOnly<Painting>()
                .Include(p => p.Author)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (painting == null)
            {
                return null;
            }

            return new PaintingFormModel()
            {
                Title = painting.Title,
                AuthorId = painting.AuthorId,
                AuthorName = string.Join(" ", new string[] { painting.Author.FirstName, painting.Author.LastName ?? string.Empty }),
                Year = painting.Year,
                GenreId = painting.GenreId,
                ArtTypeId = painting.ArtTypeId,
                BaseTypeId = painting.BaseTypeId,
                MaterialId = painting.MaterialId,
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

        public async Task<string?> GetInformationByIdAsync(int id)
        {
            IPaintingInformationModel? model = await _repository
                .AllAsReadOnly<Painting>()
                .Where(p => p.Id == id)
                .Select(p => new PaintingDetailsModel()
                {
                    AuthorName = string.Join(" ", new string[] { p.Author.FirstName, p.Author.LastName ?? string.Empty }),
                    Title = p.Title,
                    Description = p.Description,
                    HeightCm = p.HeightCm,
                    WidthCm = p.WidthCm
                })
                .FirstOrDefaultAsync();

            return model?.GetInformation();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            Painting? painting = await _repository.AllAsReadOnly<Painting>().FirstOrDefaultAsync();

            return painting == null ? false : true;
        }

        private void DeleteImageByPath(string imagePath, string rootPath)
        {
            string filePath = $"{rootPath}{imagePath.Trim('~').Replace("/", "\\")}";
            File.Delete(filePath);
        }

        private async Task SaveImageToDiskAsync(IFormFile imageFile, string ImageFileName, string rootPath)
        {
            string filePath = Path.Combine(rootPath, "Images\\Paintings", ImageFileName);

            try
            {
                using (FileStream stream = File.Create(filePath))
                {
                    await imageFile.CopyToAsync(stream);
                }
            }
            catch (Exception)
            {
                throw new ErrorWhileSavingImageToDiskException();
            }
        }

        public async Task<PaintingQueryServiceModel> AllPersonalAsync(string userId,
            int currentPage,
            int countPerPage,
            string? paintingTitle,
            bool onlyNotInExhibition = false)
        {
            var paintingsToShow = _repository.AllAsReadOnly<Painting>()
                .Where(p => p.Author.UserId == userId);

            if (paintingTitle != null)
            {
                paintingsToShow = paintingsToShow
                    .Where(p => p.Title.ToLower().Contains(paintingTitle.ToLower()));
            }

            if (onlyNotInExhibition)
            {
                paintingsToShow = paintingsToShow
                    .Where(p => p.ExhibitionId == null);
            }

            List<PaintingThumbnailModel> thumbnails = await paintingsToShow
                .Select(p => new PaintingThumbnailModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    AuthorName = (p.Author.FirstName + " " + p.Author.LastName ?? "").Trim(),
                    Description = p.Description,
                    HeightCm = p.HeightCm,
                    WidthCm = p.WidthCm,
                    ImagePath = p.ImagePath
                })
                .Skip((currentPage - 1) * countPerPage)
                .Take(countPerPage)
                .ToListAsync();

            PaintingQueryServiceModel model = new PaintingQueryServiceModel()
            {
                Thumbnails = thumbnails,
                TotalThumbnailsCount = paintingsToShow.Count()
            };

            return model;
        }

        public async Task<List<PaintingThumbnailModel>> GetPendingPaintingsForApprovalAsync(int exhibitionId, int authorId)
        {
            List<PaintingThumbnailModel> paintings = await _repository
                .AllAsReadOnly<Painting>()
                .Where(p => p.ExhibitionId == exhibitionId &&
                    p.AuthorId == authorId &&
                    p.IsAccepted == false)
                .Select(p => new PaintingThumbnailModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    AuthorName = (p.Author.FirstName + " " + p.Author.LastName ?? "").Trim(),
                    Description = p.Description,
                    HeightCm = p.HeightCm,
                    WidthCm = p.WidthCm,
                    ImagePath = p.ImagePath
                }).ToListAsync();

            return paintings;
        }
    }
}
