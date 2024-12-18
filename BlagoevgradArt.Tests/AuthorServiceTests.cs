using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Author;
using BlagoevgradArt.Core.Services;
using BlagoevgradArt.Data;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace BlagoevgradArt.Tests;

[TestFixture]
public class AuthorServiceTests
{
    private const string VladimirUserId = "7d7a4b74-dd27-4262-b932-ee5cd63a519d";
    private const string TsankoUserId = "1b6e897e-6594-4453-ade4-305d69ae8391";
    private readonly ApplicationDbContext _context;
    private readonly IRepository _repository;
    private readonly IAuthorService _authorService;

    public AuthorServiceTests()
    {
        _context = new ApplicationDbContext();
        _repository = new Repository(_context);
        _authorService = new AuthorService(_repository);

        _context.Database.EnsureCreated();
        _context.Database.Migrate();
    }

    [TestCase(VladimirUserId, 1)]
    [TestCase("abcdefu", -1)]
    public async Task ExistsByIdBehavesCorrectly(string userId, int id)
    {
        bool expectedById = _repository.AllAsReadOnly<Author>().Any(a => a.Id == id);
        bool expectedByUserId = _repository.AllAsReadOnly<Author>().Any(a => a.UserId == userId);

        bool actualById = await _authorService.ExistsByIdAsync(id);
        bool actualByUserId = await _authorService.ExistsByIdAsync(userId);

        Assert.That(actualById, Is.EqualTo(expectedById));
        Assert.That(actualByUserId, Is.EqualTo(expectedByUserId));
    }

    [TestCase(VladimirUserId)]
    [TestCase("abcdefu")]
    public async Task GetIdAsyncGetsTheCorrectId(string userId)
    {
        int expectedId = _repository.AllAsReadOnly<Author>().FirstOrDefault(a => a.UserId == userId)?.Id ?? -1;
        int actualId = await _authorService.GetIdAsync(userId);

        Assert.That(actualId, Is.EqualTo(expectedId));
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

        AssertAreEqualByJson(actualModel, expectedModel);
    }

    [Test]
    public async Task SetAuthorProfileInfoSetsTheInformationCorrectly()
    {
        AuthorFormModel expected = new AuthorFormModel()
        {
            FirstName = "TestingName",
            LastName = "TestingLastName",
            PhoneNumber = "+0123456789test"
        };

        await _authorService.SetAuthorProfileInfoAsync(expected, VladimirUserId);
        AuthorProfileInfoModel? actualModel = await _authorService.GetAuthorProfileInfoAsync(1);

        if (actualModel is null)
        {
            Assert.That(actualModel, Is.Not.Null);
            return;
        }

        Assert.That(actualModel.FirstName, Is.EqualTo(expected.FirstName));
        Assert.That(actualModel.LastName, Is.EqualTo(expected.LastName));
        Assert.That(actualModel.PhoneNumber, Is.EqualTo(expected.PhoneNumber));
    }

    [TestCase("Sonic", "Hedgehod")]
    [TestCase("Sonic", "")]
    [TestCase("Sonic", " ")]
    [TestCase("Sonic", null)]
    public async Task GetFullNameReturnsCorrectFullName(string firstName, string? lastName)
    {
        Author vladi = _repository.All<Author>().First(a => a.UserId == VladimirUserId);
        vladi.FirstName = firstName;
        vladi.LastName = lastName;

        await _repository.SaveChangesAsync();

        string expected = string.Join(" ", new string[] { firstName, lastName ?? string.Empty }).Trim();
        string actual = await _authorService.GetFullNameAsync(VladimirUserId);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(false, false, true)]
    [TestCase(true, false, true)]
    [TestCase(false, true, true)]
    [TestCase(true, true, true)]
    [TestCase(false, false, false)]
    [TestCase(false, true, false)]
    [TestCase(true, false, false)]
    [TestCase(true, true, false)]
    public async Task GetAuthorThumbnailsReturnsCorrectCollection(bool isVladiAccepted, bool isTsankoAccepted, bool mustBeAccepted)
    {
        AuthorExhibition? vladiAuthorExhibition = null;
        AuthorExhibition? tsankoAuthorExhibition = null;

        try
        {
            int exhibitionId = 1;
            vladiAuthorExhibition = _repository.All<AuthorExhibition>().First(ae => ae.AuthorId == 1);
            tsankoAuthorExhibition = _repository.All<AuthorExhibition>().First(ae => ae.AuthorId == 2);

            vladiAuthorExhibition.IsAccepted = isVladiAccepted;
            tsankoAuthorExhibition.IsAccepted = isTsankoAccepted;
            await _repository.SaveChangesAsync();

            IQueryable<Author>? authorsFiltered = _repository.AllAsReadOnly<Author>()
                .Where(a => a.AuthorExhibitions.Any(ae => ae.ExhibitionId == exhibitionId && ae.IsAccepted == mustBeAccepted));

            List<AuthorSmallThumbnailModel> expectedThumbnails = await authorsFiltered
                .Select(a => new AuthorSmallThumbnailModel()
                {
                    Id = a.Id,
                    FullName = (a.FirstName + " " + a.LastName ?? "").Trim(),
                    HasPendingPaintings = a.AuthorExhibitions.Where(ae => ae.ExhibitionId == exhibitionId && ae.AuthorId == a.Id).First().HasPendingPaintings
                }).ToListAsync();

            List<AuthorSmallThumbnailModel> actualThumbnails = await _authorService.GetAuthorThumbnailsAsync(1, mustBeAccepted);

            AssertAreEqualByJson(actualThumbnails, expectedThumbnails);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.MigrateAsync();
        }
        finally
        {
            if (vladiAuthorExhibition is not null)
            {
                vladiAuthorExhibition.IsAccepted = false;
            }

            if (tsankoAuthorExhibition is not null)
            {
                tsankoAuthorExhibition.IsAccepted = false;
            }
        }
    }

    private void AssertAreEqualByJson(object? first, object? second)
    {
        string firstSerialized = JsonSerializer.Serialize(first ?? string.Empty);
        string secondSerialized = JsonSerializer.Serialize(second ?? string.Empty);

        Assert.That(firstSerialized, Is.EqualTo(secondSerialized));
    }
}
