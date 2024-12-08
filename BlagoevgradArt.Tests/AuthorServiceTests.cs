using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Author;
using BlagoevgradArt.Core.Services;
using BlagoevgradArt.Data;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BlagoevgradArt.Tests;

[TestFixture]
public class AuthorServiceTests
{
    private const string VladimirUserId = "7d7a4b74-dd27-4262-b932-ee5cd63a519d";
    private readonly ApplicationDbContext _context;
    private readonly IRepository _repository;
    private readonly IAuthorService _authorService;

    public AuthorServiceTests()
    {
        _context = new ApplicationDbContext();
        _repository = new Repository(_context);
        _authorService = new AuthorService(_repository);
    }

    [TestCase(VladimirUserId, 1)]
    [TestCase("abcdefu", -1)]
    public async Task ExistsByIdBehavesCorrectly(string userId, int id)
    {
        bool expectedById = _repository.AllAsReadOnly<Author>().Any(a => a.Id == id);
        bool expectedByUserId = _repository.AllAsReadOnly<Author>().Any(a => a.UserId == userId);

        bool actualById = await _authorService.ExistsByIdAsync(id);
        bool actualByUserId = await _authorService.ExistsByIdAsync(userId);

        Assert.That(expectedById, Is.EqualTo(actualById));
        Assert.That(expectedByUserId, Is.EqualTo(actualByUserId));
    }

    [TestCase(VladimirUserId)]
    [TestCase("abcdefu")]
    public async Task GetIdAsyncGetsTheCorrectId(string userId)
    {
        int expectedId = _repository.AllAsReadOnly<Author>().FirstOrDefault(a => a.UserId == userId)?.Id ?? -1;
        int actualId = await _authorService.GetIdAsync(userId);

        Assert.That(expectedId, Is.EqualTo(actualId));
    }

    [TestCase(1)]
    [TestCase(-1)]
    public async Task GetAuthorProfileInfoGetsCorrectInfo(int id)
    {
        Author? author = await _repository
                .AllAsReadOnly<Author>()
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        AuthorProfileInfoModel? expectedModel = null;

        if (author is not null)
        {
            expectedModel = new AuthorProfileInfoModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                PhoneNumber = author.PhoneNumber,
                Email = author.User.Email,
                ProfilePicturePath = author.ProfilePicturePath
            };
        }

        AuthorProfileInfoModel? actualModel = await _authorService.GetAuthorProfileInfoAsync(id);

        AssertAreEqual(expectedModel, actualModel);
    }

    private void AssertAreEqual(object? first, object? second)
    {
        string firstSerialized = JsonSerializer.Serialize(first ?? string.Empty);
        string secondSerialized = JsonSerializer.Serialize(second ?? string.Empty);

        Assert.That(firstSerialized, Is.EqualTo(secondSerialized));
    }
}
