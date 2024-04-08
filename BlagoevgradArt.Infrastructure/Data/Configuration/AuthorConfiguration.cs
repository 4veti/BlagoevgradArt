using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            SeedData data = new SeedData();

            builder.HasData(new Author[] { data.Author1, data.Author2 });
        }
    }
}
