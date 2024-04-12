using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class SeedData
    {
        public BaseType[] BaseTypes { get; set; }
        public Material[] Materials { get; set; }
        public ArtType[] ArtTypes { get; set; }
        public Technique[] Techniques { get; set; }
        public Genre[] Genres { get; set; }

        public Painting[] Paintings { get; set; }

        public Exhibition[] Exhibitions { get; set; }

        public AuthorHelperUser AuthorHelperUser1 { get; set; }
        public AuthorHelperUser AuthorHelperUser2 { get; set; }
        public Author Author1 { get; set; }
        public Author Author2 { get; set; }

        public GalleryHelperUser GalleryHelperUser { get; set; }
        public Gallery Gallery { get; set; }

        public AuthorExhibition[] AuthorsExhibitions { get; set; }
        public PaintingMaterial[] PaintingsMaterials { get; set; }

        public SeedData()
        {
            SeedBaseTypes();
            SeedMaterials();
            SeedArtTypes();
            SeedTechniques();
            SeedGenres();
            SeedPaintings();
            SeedAuthors();
            SeedGalleries();
            SeedExhibitions();
            SeedPaintingsMaterials();
            SeedAuthorsExhibitions();
        }

        private void SeedBaseTypes()
        {
            BaseTypes = new BaseType[]
            {
                new BaseType { Id = 1, Name = "Платно"},
                new BaseType { Id = 2, Name = "Хартия"},
                new BaseType { Id = 3, Name = "Стъкло"},
                new BaseType { Id = 4, Name = "Дърво"},
                new BaseType { Id = 5, Name = "Картон"}
            };
        }

        private void SeedMaterials()
        {
            Materials = new Material[]
            {
                new Material {Id = 1, Name = "Акварел"},
                new Material {Id = 2, Name = "Темпера"},
                new Material {Id = 3, Name = "Маслени бои"},
                new Material {Id = 4, Name = "Сух пастел"},
                new Material {Id = 5, Name = "Маслен пастел"},
                new Material {Id = 6, Name = "Молив"},
                new Material {Id = 7, Name = "Мастило"},
                new Material {Id = 8, Name = "Дърво"},
                new Material {Id = 9, Name = "Колаж"}
            };
        }

        private void SeedArtTypes()
        {
            ArtTypes = new ArtType[]
            {
                new ArtType { Id = 1, Name = "Живопис"},
                new ArtType { Id = 2, Name = "Графика"},
                new ArtType { Id = 3, Name = "Рисунка"},
                new ArtType { Id = 4, Name = "Дърворезба"},
                new ArtType { Id = 5, Name = "Керамика"},
                new ArtType { Id = 6, Name = "Витраж"},
                new ArtType { Id = 7, Name = "Металопластика"},
                new ArtType { Id = 8, Name = "Декоративна скулптора"},
                new ArtType { Id = 9, Name = "Бижутерия"},
                new ArtType { Id = 10, Name = "Оригами"},
                new ArtType { Id = 12, Name = "Друго"}
            };
        }

        private void SeedTechniques()
        {
            Techniques = new Technique[]
            {
                new Technique { Id = 1, Name = "Висок печат"},
                new Technique { Id = 2, Name = "Дълбок печат"},
                new Technique { Id = 3, Name = "Плосък печат (литография)"},
                new Technique { Id = 4, Name = "Сериграфия (ситопечат)"},
                new Technique { Id = 5, Name = "Дигитални техники"}
            };
        }

        private void SeedGenres()
        {
            Genres = new Genre[]
            {
                new Genre { Id = 1, Name = "Портрет"},
                new Genre { Id = 2, Name = "Пейзаж"},
                new Genre { Id = 3, Name = "Натюрморт"},
                new Genre { Id = 4, Name = "Фигурална композиция"},
                new Genre { Id = 5, Name = "Абстракция"}
            };
        }

        private void SeedAuthors()
        {
            var hasher = new PasswordHasher<AuthorHelperUser>();

            AuthorHelperUser1 = new AuthorHelperUser()
            {
                Id = "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                UserName = "vladimaistora@mail.com",
                NormalizedUserName = "vladimaistora@mail.com",
                Email = "vladimaistora@mail.com",
                NormalizedEmail = "vladimaistora@mail.com"
            };

            AuthorHelperUser1.PasswordHash = hasher.HashPassword(AuthorHelperUser1, "vladi123456");

            AuthorHelperUser2 = new AuthorHelperUser()
            {
                Id = "1b6e897e-6594-4453-ade4-305d69ae8391",
                UserName = "tsankolavrenov@mail.com",
                NormalizedUserName = "tsankolavrenov@mail.com",
                Email = "tsankolavrenov@mail.com",
                NormalizedEmail = "tsankolavrenov@mail.com"
            };

            AuthorHelperUser2.PasswordHash = hasher.HashPassword(AuthorHelperUser2, "tsanko123456");

            Author1 = new Author()
            {
                Id = 1,
                UserId = "7d7a4b74-dd27-4262-b932-ee5cd63a519d",
                FirstName = "Vladimir",
                LastName = "Maistora",
                PhoneNumber = "+359888123456",
                ProfilePicturePath = "BlagoevgradArt\\Images\\Authors\\Tsanko_Lavrenov.jpg"
            };

            Author2 = new Author()
            {
                Id = 2,
                UserId = "1b6e897e-6594-4453-ade4-305d69ae8391",
                FirstName = "Tsanko",
                LastName = "Lavrenov",
                PhoneNumber = "+359888654321",
                ProfilePicturePath = "BlagoevgradArt\\Images\\Authors\\Tsanko_Lavrenov.jpg"
            };
        }

        private void SeedPaintings()
        {
            Paintings = new Painting[]
            {
                new Painting {Id = 1, Title = "Жена", AuthorId = 1, Year = 1920, GenreId = 1, ArtTypeId = 3, BaseTypeId = 1,
                    Description = "Тази картина вероятно е от XXв.", ExhibitionId = 1,
                    HeightCm = 69, WidthCm = 42, IsAvailable = false, ImagePath = "BlagoevgradArt\\Images\\Paintings\\Vladimir_Woman.jpg"},

                new Painting {Id = 2, Title = "Майка", AuthorId = 1, Year = 1923, GenreId = 1, ArtTypeId = 3, BaseTypeId = 2,
                    Description = "Тази картина изобразява неизвестна жена от миналия век.", ExhibitionId = 1,
                    HeightCm = 50, WidthCm = 30, IsAvailable = false, ImagePath = "BlagoevgradArt\\Images\\Paintings\\Vladimir_Mother.jpg"},

                new Painting {Id = 3, Title = "Хилендарския манастир", AuthorId = 2, Year = 1945, GenreId = 2, ArtTypeId = 1, BaseTypeId = 1,
                    Description = "Пейзаж на Хилендарския манастир.", ExhibitionId = 1,
                    HeightCm = 55, WidthCm = 73, IsAvailable = false,  ImagePath = "BlagoevgradArt\\Images\\Paintings\\Tsanko_Hilendarski.jpg"}
            };
        }

        private void SeedGalleries()
        {
            var hasher = new PasswordHasher<GalleryHelperUser>();

            GalleryHelperUser = new GalleryHelperUser()
            {
                Id = "a9d96207-30f8-40cb-a670-adc6acd76fba",
                UserName = "gallery@mail.com",
                NormalizedUserName = "gallery@mail.com",
                Email = "gallery@mail.com",
                NormalizedEmail = "gallery@mail.com"
            };

            GalleryHelperUser.PasswordHash = hasher.HashPassword(GalleryHelperUser, "gallery123456");

            Gallery = new Gallery()
            {
                Id = 1,
                UserId = "a9d96207-30f8-40cb-a670-adc6acd76fba",
                Name = "АртГалерия",
                Address = "ул. \"Горно нанадолнище\" №0, кв. \"Кал до колене\", Благоевград.",
                WorkingTime = "Пон-Пет 08:30-19:30",
                PhoneNumber = "+359888696969",
                Description = "Най-дейната и известна галерия в югозапада."
            };
        }

        private void SeedExhibitions()
        {
            Exhibitions = new Exhibition[]
            {
                new Exhibition()
                {
                    Id = 1,
                    Name = "Началото на българското възрожденско изкуство.",
                    OpeningDate = DateTime.Today.AddDays(25).AddHours(15),
                    Description = "Запознайте се с някои от основоположниците на българското възрожденско изкуство.",
                    GalleryId = 1
                }
            };
        }

        private void SeedAuthorsExhibitions()
        {
            AuthorsExhibitions = new AuthorExhibition[]
            {
                new AuthorExhibition() { AuthorId = 1, ExhibitionId = 1 },
                new AuthorExhibition() { AuthorId = 2, ExhibitionId = 1 }
            };
        }

        private void SeedPaintingsMaterials()
        {
            PaintingsMaterials = new PaintingMaterial[]
            {
                new PaintingMaterial() { PaintingId = 1, MaterialId = 1 },
                new PaintingMaterial() { PaintingId = 2, MaterialId = 2 },
                new PaintingMaterial() { PaintingId = 3, MaterialId = 1 },
                new PaintingMaterial() { PaintingId = 3, MaterialId = 6 },
            };
        }
    }
}
