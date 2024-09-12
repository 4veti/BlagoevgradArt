﻿using BlagoevgradArt.Core.Models.Painting;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IPaintingService
    {
        Task<int> AddPaintingAsync(PaintingFormModel model, string userId, string rootPath);

        Task<PaintingDetailsModel?> GetPaintingDetailsAsync(int id);

        Task EditPaintingAsync(PaintingFormModel model, int id, string rootPath);

        Task<PaintingFormModel?> GetPaintingFormModel(int id);

        Task<PaintingQueryServiceModel> AllAsync(int currentPage,
            int countPerPage,
            string? authorFirstName,
            string? artType);

        Task<PaintingQueryServiceModel> AllPersonalAsync(string userId,
            int currentPage,
            int countPerPage,
            string? paintingTitle);

        Task DeleteImageAsync(int id, string rootPath);

        Task<string?> GetInformationById(int id);

        Task<bool> ExistsByIdAsync(int id);
    }
}
